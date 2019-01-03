/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var AdminSettingGetServerInfoUrl='/admin/setting/GetServerInfo';
/**
* 'var result= await AdminSettingGetServerInfo(params);'
**/
function AdminSettingGetServerInfo(useHttp)
{
    return api(AdminSettingGetServerInfoUrl,{},useHttp).sync();
}
/**
* 'AdminSettingGetServerInfoAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingGetServerInfoAsync(useHttp)
{
    return api(AdminSettingGetServerInfoUrl,{},useHttp);
}
var AdminSettingGetFileAndTCloudTokenUrl='/admin/setting/GetFileAndTCloudToken';
/**
* 'var result= await AdminSettingGetFileAndTCloudToken(params);'
**/
function AdminSettingGetFileAndTCloudToken(name,useHttp)
{
    return api(AdminSettingGetFileAndTCloudTokenUrl,{name:name},useHttp).sync();
}
/**
* 'AdminSettingGetFileAndTCloudTokenAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingGetFileAndTCloudTokenAsync(name,useHttp)
{
    return api(AdminSettingGetFileAndTCloudTokenUrl,{name:name},useHttp);
}
var AdminSettingSaveTCloudInfoUrl='/admin/setting/SaveTCloudInfo';
/**
* 'var result= await AdminSettingSaveTCloudInfo(params);'
**/
function AdminSettingSaveTCloudInfo(id,key,host,useHttp)
{
    return api(AdminSettingSaveTCloudInfoUrl,{id:id,key:key,host:host},useHttp).sync();
}
/**
* 'AdminSettingSaveTCloudInfoAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingSaveTCloudInfoAsync(id,key,host,useHttp)
{
    return api(AdminSettingSaveTCloudInfoUrl,{id:id,key:key,host:host},useHttp);
}
var AdminSettingGetTCloudInfoUrl='/admin/setting/GetTCloudInfo';
/**
* 'var result= await AdminSettingGetTCloudInfo(params);'
**/
function AdminSettingGetTCloudInfo(useHttp)
{
    return api(AdminSettingGetTCloudInfoUrl,{},useHttp).sync();
}
/**
* 'AdminSettingGetTCloudInfoAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingGetTCloudInfoAsync(useHttp)
{
    return api(AdminSettingGetTCloudInfoUrl,{},useHttp);
}
var AdminSettingESTestUrl='/admin/setting/ESTest';
/**
* 'var result= await AdminSettingESTest(params);'
**/
function AdminSettingESTest(word,useHttp)
{
    return api(AdminSettingESTestUrl,{word:word},useHttp).sync();
}
/**
* 'AdminSettingESTestAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingESTestAsync(word,useHttp)
{
    return api(AdminSettingESTestUrl,{word:word},useHttp);
}
var AdminSettingSignoutUrl='/admin/setting/Signout';
/**
* 'var result= await AdminSettingSignout(params);'
**/
function AdminSettingSignout(useHttp)
{
    return api(AdminSettingSignoutUrl,{},useHttp).sync();
}
/**
* 'AdminSettingSignoutAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingSignoutAsync(useHttp)
{
    return api(AdminSettingSignoutUrl,{},useHttp);
}
var AdminSettingLoginUrl='/admin/setting/Login';
/**
* 'var result= await AdminSettingLogin(params);'
**/
function AdminSettingLogin(name,pwd,useHttp)
{
    return api(AdminSettingLoginUrl,{name:name,pwd:pwd},useHttp).sync();
}
/**
* 'AdminSettingLoginAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingLoginAsync(name,pwd,useHttp)
{
    return api(AdminSettingLoginUrl,{name:name,pwd:pwd},useHttp);
}
var AdminSettingChangePwdUrl='/admin/setting/ChangePwd';
/**
* 'var result= await AdminSettingChangePwd(params);'
**/
function AdminSettingChangePwd(pwd,rpwd,useHttp)
{
    return api(AdminSettingChangePwdUrl,{pwd:pwd,rpwd:rpwd},useHttp).sync();
}
/**
* 'AdminSettingChangePwdAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingChangePwdAsync(pwd,rpwd,useHttp)
{
    return api(AdminSettingChangePwdUrl,{pwd:pwd,rpwd:rpwd},useHttp);
}
var AdminSettingUpdateSettingUrl='/admin/setting/UpdateSetting';
/**
* 'var result= await AdminSettingUpdateSetting(params);'
**/
function AdminSettingUpdateSetting(title,host,about,imghost,useHttp)
{
    return api(AdminSettingUpdateSettingUrl,{title:title,host:host,about:about,imghost:imghost},useHttp).sync();
}
/**
* 'AdminSettingUpdateSettingAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingUpdateSettingAsync(title,host,about,imghost,useHttp)
{
    return api(AdminSettingUpdateSettingUrl,{title:title,host:host,about:about,imghost:imghost},useHttp);
}
var AdminSettingReCreateIndexUrl='/admin/setting/ReCreateIndex';
/**
* 'var result= await AdminSettingReCreateIndex(params);'
**/
function AdminSettingReCreateIndex(useHttp)
{
    return api(AdminSettingReCreateIndexUrl,{},useHttp).sync();
}
/**
* 'AdminSettingReCreateIndexAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingReCreateIndexAsync(useHttp)
{
    return api(AdminSettingReCreateIndexUrl,{},useHttp);
}
var AdminSettingUploadImageUrl='/admin/setting/UploadImage';
/**
* 'var result= await AdminSettingUploadImage(params);'
**/
function AdminSettingUploadImage(file,useHttp)
{
    return api(AdminSettingUploadImageUrl,{file:file},useHttp).sync();
}
/**
* 'AdminSettingUploadImageAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingUploadImageAsync(file,useHttp)
{
    return api(AdminSettingUploadImageUrl,{file:file},useHttp);
}
var AdminSettingReCreateJWTUrl='/admin/setting/ReCreateJWT';
/**
* 'var result= await AdminSettingReCreateJWT(params);'
**/
function AdminSettingReCreateJWT(useHttp)
{
    return api(AdminSettingReCreateJWTUrl,{},useHttp).sync();
}
/**
* 'AdminSettingReCreateJWTAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingReCreateJWTAsync(useHttp)
{
    return api(AdminSettingReCreateJWTUrl,{},useHttp);
}
var AdminSettingGetSettingUrl='/admin/setting/GetSetting';
/**
* 'var result= await AdminSettingGetSetting(params);'
**/
function AdminSettingGetSetting(useHttp)
{
    return api(AdminSettingGetSettingUrl,{},useHttp).sync();
}
/**
* 'AdminSettingGetSettingAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingGetSettingAsync(useHttp)
{
    return api(AdminSettingGetSettingUrl,{},useHttp);
}
var AdminSettingCloseSessionUrl='/admin/setting/CloseSession';
/**
* 'var result= await AdminSettingCloseSession(params);'
**/
function AdminSettingCloseSession(ids,useHttp)
{
    return api(AdminSettingCloseSessionUrl,{ids:ids},useHttp,true).sync();
}
/**
* 'AdminSettingCloseSessionAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingCloseSessionAsync(ids,useHttp)
{
    return api(AdminSettingCloseSessionUrl,{ids:ids},useHttp,true);
}
var AdminSettingListConnUrl='/admin/setting/ListConn';
/**
* 'var result= await AdminSettingListConn(params);'
**/
function AdminSettingListConn(index,useHttp)
{
    return api(AdminSettingListConnUrl,{index:index},useHttp).sync();
}
/**
* 'AdminSettingListConnAsync(params).execute(function(result){},useHttp);'
**/
function AdminSettingListConnAsync(index,useHttp)
{
    return api(AdminSettingListConnUrl,{index:index},useHttp);
}
