source lint.env
qodana scan -e QODANA_TOKEN=$QODANA_TOKEN --fail-threshold 1 -s false --source-directory NarouBackend/ --config qodana-backend.yaml  --property=qodana.net.solution=NarouBackend.sln