$(function () {
  var editor = $("#modal-dialog"); // <-- 获得 modal dialog 的 jQuery 对象

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

/*
// 页面：
<div id="modal-dialog"></div>                           <-- 对话框容器
<partial name="_ModalDialogPlaceHolder"></partial>      <-- 对话框容器

<button class="btn btn-primary" data-toggle="modal-dialog" data-url="@Url.Action("Modal")">Show Modal</button>

// 打开 modal dialog 的按钮
// 在 js 中得到按钮对象，读取 button 对象中 data-url 属性的值
// 从 url 中获取对话框的内容：控制器返回分布视图，对话框内容保存在对应的分布视图中
// controller 
[HttpGet]
public IActionResult Modal()
{
    var model = new DemoViewModel();
    return PartialView("_ModalDialog", model);
}

// partial view (modal dialog content)

<div class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">登录</h4>
            </div>
            <div class="modal-body">
                <form method="post" asp-action="Modal">
                    
                </form>
            </div>
            <div class="modal-footer">
                <button class="btn btn-primary" data-dismiss="modal">Close</button>
                <button class="btn btn-primary" data-save="modal">Submit</button>
            </div>

        </div>
    </div>
</div>

// js 中提交表单



*/
