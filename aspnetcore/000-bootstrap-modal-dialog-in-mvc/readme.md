# 在 aspnetcore mvc 中使用 bootstrap modal dialog
## 必备
- aspnetcore mvc
- bootstrap
- jquery

## 组件
- 控制器（Controller）和对应的 Action
- 模态对话框内容分布视图
- 页面上的模态对话框占位元素和打开按钮/链接
  - 打开按钮必须有 `data-toggle` 和 `data-url` 属性
- javascript 逻辑：
  1. 得到打开按钮/链接的 jQuery 对象
  2. 读取 `data-url` 的值
  3. 异步获得对话框内容的分布视图，由控制器返回
  4. 提交关闭模态对话框
  5. 刷新d昂前页面或者啥也不做

## 部分代码 
### 页面内容 `Index.cshtml`
``` html
<div id="modal-dialog"></div>                           
<partial name="_ModalDialogPlaceHolder"></partial>

<button class="btn btn-primary" data-toggle="modal-dialog" data-url="@Url.Action("Modal")">Show Modal</button>
```

### 控制器 `HomeController.cs`

```csharp
[HttpGet]
public IActionResult Modal()
{
    var model = new DemoViewModel
    {
        Username = "sam.zhang",
        Password = "1234",
        Email  = "sam.zhang@google.com"
    };
    return PartialView("_ModalDialog", model);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Modal(DemoViewModel input)
{
    _logger.LogWarning($"{input.Username} has signed in");
    return RedirectToAction(nameof(Index));
}
```

### 页面调用逻辑 `site.js`

```javascript
$(function () {
  var editor = $("#modal-dialog");

  $('button[data-toggle="modal-dialog"]').click(function ($event) {
    var url = $(this).data("url");
    $.get(url).done(function (data) {
      editor.html(data);
      editor.find(".modal").modal("show");
    });
  });

  editor.on("click", '[data-save="modal"]', function ($event) {
    var form = $(this).parents(".modal").find("form");
    var url = form.attr("action");
    console.log(url);
    var data = form.serialize();
    $.post(url, data).done(function (data) {
      editor.find(".modal").modal("hide");
    });
  });
});
```

### Modal Dialog 内容分布视图：`_ModalDialog.cshtml`

```html
<div class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">登录</h4>
      </div>
      <div class="modal-body">
        <form method="post" asp-action="Modal"></form>
      </div>
      <div class="modal-footer">
        <button class="btn btn-primary" data-dismiss="modal">Close</button>
        <button class="btn btn-primary" data-save="modal">Submit</button>
      </div>
    </div>
  </div>
</div>
```
