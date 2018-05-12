# SKit

可以单独使用在dotNetCore的Console下，也可以作为中间件加入到Asp.NetCore中

## 在Asp.Net Core Mvc下使用

建议作为中间件使用于Asp.net core mvc下, 使用asp.net core mvc的http接口创建内部管理API, SKit处理tcp部分来自客户端的数据.

### 一, 使用nuget安装SKit.AspNetCore

  Install-Package SKit.AspNetCore
  
### 二, 修改Startup类, 添加SKit中间件(AddSKit和UseSKit两行代码)
```C#
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSKit<StringSerializer>();      
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSKit();
            app.UseMvc();
        }
```
### 三, 创建你的逻辑Module
```C#
    public class ChatModule: GameModule
    {
        private GameServer _server;
        private ILogger<ChatModule> _logger;
        public ChatRoomController(GameServer server, ILogger<ChatModule> logger)
        {
            _server = server;
            _logger = logger;
        }
    }
```
    * 必须继承GameModule
    * 可以使用DI容器在构造函数中获取其他依赖组件(比如日志组件, TCP服务器实例本身)

### 四, 添加处理函数
  
    你有两种方式添加处理函数:
    
    1, 如Asp.net core mvc类似的方式直接在Module类中添加处理函数:
 ```C#
        [GameCommandOptions(allowAnonymous:true, asynchronous:true)]
        public int Call_Chat(string msg)
        {
            string str = msg;
            _server.BroadcastAllSessionAsync(str);
            _logger.LogDebug(str);
            return 0;
        }
```
        可以对处理函数使用GameCommandOptionsAttribute特性(非必需).
        * allowAnonymous:true, 表明其允许匿名用户, 否则用户必须在登录(即使用Session.Login()方法)之后才能访问该处理函数, 匿名情况下将丢弃该包/或者踢出非法用户.
        * asynchronous:true, 使其将在收到消息之后直接执行而非放入主循环同步处理.
        
    2, 创建命令形式, 继承GameCommand<TRequest>类型并实现ExecuteCommand()方法 :
    (泛型类型为请求消息类型)
```C#
    public class ChatCommand : GameCommand<string>
    {
        PlayerModule _playerModule;
        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
        }
        public override int ExecuteCommand()
        {
            string str = Request;
            _server.BroadcastAllSessionAsync(str);
            _logger.LogDebug(str);
            return 0;
        }
    }
```
    Command不支持DI容器, 但可以通过获得Module然后从Module获取需要的组件和数据. 建议所有需要共享的接口通过Module开放给其他地方使用. 
  
### 另外
   你可以通过添加其他Module来实现数据存取\日志\监控管理等功能.
   
