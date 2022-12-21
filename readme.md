# Demo parallel process, using **Parallel.ForEachAsync** & **Parallel.ForEach**

* Create solution using *dotnet new sln*

```cmd
dotnet new sln
```

* Using **dotnet new --list** show templates enabled:

```cmd
dotnet new --list
```

* Create and add project to solution using *dotnet new console* and *dotnet sln add*

```cmd
dotnet new console -o parallel-proj
dotnet sln add parallel-proj/parallel-proj.csproj
```

* Add version control, create .gitignore file, using comand *dotnet new gitignore*

```cmd
dotnet new gitignore
```

* Run project using **dotnet run**
```cmd
dotnet run --project parallel-proj/parallel-proj.csproj
```
* Use Stopwatch by elapsed times

```cs
Stopwatch stopwatch = new Stopwatch(); 
stopwatch.Start();
Console.WriteLine($"End elapsed {stopwatch.Elapsed}");
```


* Use flags TEST_PARALLEL_FLAG with Environment Variable

Set environment variable (linux)

```cmd
export TEST_PARALLEL_FLAG="T"
echo $TEST_PARALLEL_FLAG
```

* Switch parallel/non parallel in code

* Use flags TEST_ASYNC_FLAG with Environment Variable

Set environment variable (linux)

```cmd
export TEST_ASYNC_FLAG="T"
echo $TEST_ASYNC_FLAG
```

* Switch async/non async in code

* Use flags SLEEP_TIME_MILISECONDS with Environment Variable

Set environment variable (linux)

```cmd
export SLEEP_TIME_MILISECONDS=1200
echo $SLEEP_TIME_MILISECONDS
```

* Add docker file, using extension vscode

* Build image with docker build

```cmd
docker build -f parallel-proj/Dockerfile -t parallel-proj:1.0 .
```

* Run docker without environment variables, defautl F and F:

```cmd
docker run parallel-proj:1.0
```

* Run docker with environment variables:

```cmd
docker run -e TEST_PARALLEL_FLAG=T -e TEST_ASYNC_FLAG=T parallel-proj:1.0
```
