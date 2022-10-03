# Specflow

This project uses Specflow so that we can easily use Gherkin with xUnit.

To get a hello-world sample go to :

https://docs.specflow.org/projects/getting-started/en/latest/index.html

To install the LivingDoc CLI :

```bash
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

To run the cli tool

```bash
cd ./bin/Debug/net6.0
livingdoc test-assembly  ShoppingCartTests.dll -t TestExecution.json
exec firefox LivingDoc.html > /dev/null
cd -
```