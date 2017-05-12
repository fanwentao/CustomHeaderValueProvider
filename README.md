# ASP.NET Web API 自定义头部值提供器

提供了一种使用模型绑定来获取和验证ASP.NET Web API 2 中自定义请求头的简单方法.

默认情况下参数是简单类型，框架将从Url和路由获取值.<br>
https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api

## 使用
 * 注册全局值提供器工厂<br>
 * 方法参数添加特性<br>

```C#
config.Services.Insert(typeof(ValueProviderFactory), 0, new CustomHeaderValueProviderFactory());
[FromHeader]int page = 1
``` 



