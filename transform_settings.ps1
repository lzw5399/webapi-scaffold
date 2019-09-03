$settings = get-content "src/api/Doublelives.Api/appsettings.json" | convertfrom-json;
$settings.TencentCos.AppId = $env:AppId;
$settings.TencentCos.SecretId = $env:SecretId;
$settings.TencentCos.SecretKey = $env:SecretKey;
$settings.TencentCos.Bucket = $env:Bucket;
$settings.TencentCos.Region = $env:Region;
$settings.TencentCos.DurationSecond = $env:DurationSecond;
$settings.TencentCos.BaseUrl = $env:BaseUrl;
set-content "src/api/Doublelives.Api/appsettings.json" ($settings | convertto-json);