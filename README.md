# dotnet_core_framework
一套基于模块化思想的.net core框架
借鉴ABP的模块化思想，通过标签式的接口定义模块，在ConfigureServices中引入到该标签式接口，将返回的程序集注册到.net core下的IOC容器中。
即可实现模块化注入。

