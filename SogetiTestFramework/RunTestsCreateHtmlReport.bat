nunit3-console.exe --labels=All --out=SampleTestProject\bin\Debug\TestResult.txt "--result=SampleTestProject\bin\Debug\TestResult.xml;format=nunit2" SampleTestProject\bin\Debug\SampleTestProject.dll
specflow.exe nunitexecutionreport SampleTestProject\SampleTestProject.csproj /xmlTestResult:SampleTestProject\bin\Debug\TestResult.xml /out:SampleTestProject\bin\Debug\MyNewResult.html