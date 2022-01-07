# Upload de Arquivo

<br>
### HTML
```html
<input type="file" class="form-control" id="file1" name="file">
<input type="button" ng-click="uploadFiles()" value="Upload" />

```

------------
<br>
### JavaScript
```javascript
function uploadFiles() {
        var file = document.getElementById('file1').files[0];
        var read = new FileReader();

        read.onloadend = function (e) {
            var data = e.target.result;
            var dados = {
                model: { data: btoa(data), filename: file.name }
            }
            $http.post('/Timesheet/Apontamento/UploadFile', JSON.stringify(dados),
                {
                    headers: { 'Content-Type': 'application/json'}
                }).success(function (response) {
                    $scope.IsVisible = $scope.IsVisible = true;
                    $scope.response_msg = response;
                });
        }
        read.readAsBinaryString(file);
        return;
       

        
        // ENVIANDO OS ARQUIVOS.
       
    }
```

------------

<br>
### AngularJS
```javascript
$scope.uploadFiles = function (files) {
        
        var file = document.getElementById('file1').files[0];
        var read = new FileReader();

        read.onloadend = function (e) {
            var data = e.target.result;
            var dados = {
                model: { data: btoa(data), filename: file.name }
            }


            $http.post('/Timesheet/Apontamento/UploadFile', JSON.stringify(dados),
                {
                    //'file_Name':$scope.file_name;transformRequest: angular.identity,
                    headers: { 'Content-Type': 'application/json'}
                }).success(function (response) {
                    $scope.IsVisible = $scope.IsVisible = true;
                    $scope.response_msg = response;
                    // alert(response);// $scope.select();
                });
        }
        read.readAsBinaryString(file);
        return;
       

        
        // ENVIANDO OS ARQUIVOS.
       
    }
```

------------

### .NET
<br>
##### Model.cs
```csharp
public class Model
    {
        public string  data { get; set; }
        public string filename { get; set; }
    }
```

<br>
#####Controller
```csharp
 [HttpPost]
        public JsonResult UploadFile(Model model)
        {
            var objPessoa = Helper.GetCurrentPessoa();
            var FileContent = Convert.FromBase64String(model.data);
            try
            {
                string ext = model.filename.ToString().Split('.').Last();
                string NomeArquivo = $"{objPessoa.Id}-{DateTime.Now.ToString("dd-MM-yyy-HH-mm-ss")}.{ext}";
                string mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("MMMM").ToLower());
                string path = $@"\\<<PATH SAVE TO FILE >>";

                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                byte[] bytes = Convert.FromBase64String(model.data);
                using (var imageFile = new FileStream($@"{path}\{NomeArquivo}", FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                var objResult = new EventResultJsonViewModel() { Success = true, Msg = "" };
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var objResultErro = new EventResultJsonViewModel() { Success = false, Msg = ex.Message };
                return Json(objResultErro, JsonRequestBehavior.AllowGet);
            }
            
        }
```







