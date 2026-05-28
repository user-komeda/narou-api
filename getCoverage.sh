#!/bin/sh

check_coverage() {
    coverage_type="$1"
    error_message="$2"

    grep '<function ' output.xml | grep 'namespace="NarouApp' | while IFS= read -r line
    do
        name=$(echo "$line" | sed -n 's/.*name="\([^"]*\)".*/\1/p')
        namespace=$(echo "$line" | sed -n 's/.*namespace="\([^"]*\)".*/\1/p')
        type_name=$(echo "$line" | sed -n 's/.*type_name="\([^"]*\)".*/\1/p')
        coverage=$(echo "$line" | sed -n "s/.*${coverage_type}=\"\([^\"]*\)\".*/\1/p")

        if [ -z "$coverage" ]; then
            continue
        fi

        echo "$namespace.$type_name.$name"

        coverage_int=$(echo "$coverage" | awk '{printf("%d\n",$1+=$1<0?0:0.999)}')

        if [ 100 -gt "$coverage_int" ]; then
            echo "${coverage_type}=$coverage"
            echo "failed: $namespace.$type_name.$name"
            echo "$error_message"
            exit 1
        fi
    done
}

check_coverage "block_coverage" "command error1"

echo "=================="

check_coverage "line_coverage" "command error"