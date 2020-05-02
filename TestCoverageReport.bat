set testTool="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
packages\OpenCover.4.7.922\tools\OpenCover.Console.exe -target:%testTool% -targetargs:"FutureTest\bin\Debug\FutureTest.dll" -output:CoverageReport\File.xml -register:user -filter:"+[Future]* -[FutureTest]*" 


packages\ReportGenerator.4.5.6\tools\net47\ReportGenerator.exe -reports:CoverageReport\*.xml -targetdir:CoverageReport\html sourcedirs:FutureTest\bin\Debug
