#!/bin/sh
pwd
source lint.env
qodana scan -e QODANA_TOKEN=$QODANA_TOKEN --fail-threshold 1 -s false