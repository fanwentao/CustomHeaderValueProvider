# ASP.NET Web API 自定义头部值提供器

提供了一种使用模型绑定来获取和验证ASP.NET Web API 2 中自定义请求头的简单方法.<br>
默认情况下参数是简单类型，框架将从Url和路由获取值.通过实现IUriValueProviderFactory接口来扩展框架行为.<br>

* Url
* RouteData 
* CustomHeader


https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api


## 使用
 * 注册值提供器工厂到服务容器<br>


```C#
// 注册值提供器工厂到服务容器
config.Services.Insert(typeof(ValueProviderFactory), 0, new CustomHeaderValueProviderFactory());

// 方法参数必须是可选参数.
public IHttpActionResult Method(int page = 1)

// 自定义类型
// X-Page :10
// X-Index :10
public IHttpActionResult Method([FromHeader]Pager model)
{
     model.Page
     model.Index
}

``` 



