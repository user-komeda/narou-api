#!/bin/sh -e
STRLIST=`grep -o "<function[^s].*" output.xml | awk '{print $4, $5, $7, $8}'`
for STR in $STRLIST #「list*」がワードリストです
do
    echo $STR | grep "name=.*"
    nnn=`echo $STR | grep "block_coverage=.*"`
    if [ -z $nnn ]; then 
      continue 
    fi
   block_coverage=`echo $STR | grep "block_coverage=.*"| sed -e "s/^block_coverage=\"\([^\"]*\)\".*$/\1/g" | awk '{printf("%d\n",$1+=$1<0?0:0.999)}'`
   if [ 100 -gt $block_coverage ] ; then 
        echo "command error1"
        exit 0
   fi
done
echo "=================="
for STR in $STRLIST #「list*」がワードリストです
do
    echo $STR | grep "name=.*"
    nnn=`echo $STR | grep "line_coverage=.*"| sed '/^$/d'`
    if [ -z $nnn ]; then
      continue 
    fi
   line_coverage=`echo $STR | grep "line_coverage=.*"| sed -e "s/^line_coverage=\"\([^\"]*\)\".*$/\1/g" | awk '{printf("%d\n",$1+=$1<0?0:0.999)}'`
   if [ 100 -gt $line_coverage ] ; then 
         echo "command error"
         exit 0 
   fi
done

