source lint.env
qodana scan -e QODANA_TOKEN=$QODANA_TOKEN --fail-threshold 1 -s false --source-directory NarouApp/ --config ../../qodana-front.yaml  --property=qodana.net.solution=NarouApp.sln