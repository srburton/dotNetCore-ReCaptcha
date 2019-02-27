[![License: MIT](https://www.google.com/recaptcha/intro/images/hero-recaptcha-invisible.gif)](https://www.google.com/recaptcha/)

# ReCaptcha Unofficial v1.0

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![License: MIT](https://img.shields.io/badge/build-passing-brightgreen.svg)]()
[![License: MIT](https://img.shields.io/github/release/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](https://img.shields.io/github/tag-date/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](https://img.shields.io/github/languages/count/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](https://img.shields.io/github/last-commit/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](https://img.shields.io/github/languages/code-size/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](https://img.shields.io/github/issues-raw/srburton/dotNetCore-ReCaptcha.svg)]()
[![License: MIT](	https://img.shields.io/github/issues-closed/srburton/dotNetCore-ReCaptcha.svg)]()





### Install

```shell
>> Install-Package App.Infra.Integration.ReCaptcha
 or
>> dotnet add package App.Infra.Integration.ReCaptcha
```

---

### Attributes
```c#
 [ReCaptcha]
 
 [ReCaptchaIgnore]
```

### TagHelper
```cshtml
  @Html.ReCaptcha()
```
---

### Startup
```c#
services
  .AddMvc(options => {
      
      options.Filters.Add(new ReCaptchaActionFilter( reCaptcha => {
          reCaptcha.PublicKey = "you-public";
          reCaptcha.SecretKey = "you-secret";
          reCaptcha.Redirect  = "/access/denied"; /Custom
      }));
  })
 .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

```

### Controller [Any] 
```c#
    [ReCaptcha]
    public class ExampleController : Controller
    {        
        [HttpGet]        
        public IActionResult Index()
        {
            //...
        }        
        
        [HttpGet]        
        public IActionResult Index(object obj)
        {
            //...
        }  
    }        
```

### Action [Ignore] 
```c#
    [ReCaptcha]
    public class ExampleController : Controller
    {        
        [HttpGet]    
        [ReCaptchaIgnore]
        public IActionResult Index()
        {
            //...
        }   
        
        [HttpPost]   
        public IActionResult Index(object obj)
        {
            //...
        }          
    }        
```

### Action [Unique] 
```c#
    
    public class ExampleController : Controller
    {        
        [HttpGet]    
        public IActionResult Index()
        {
            //...
        }   
        
        [HttpPost]   
        [ReCaptcha]
        public IActionResult Index(object obj)
        {
            //...
        }          
    }        
```


### Index.cshtml 
```cshtml
   <form asp-route="YouRoute" method="post">

    @Html.ReCaptcha()
    
  </form>        
```

