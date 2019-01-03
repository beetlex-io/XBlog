/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var AdminPhotoAddUrl='/admin/photo/Add';
/**
* 'var result= await AdminPhotoAdd(params);'
**/
function AdminPhotoAdd(title,useHttp)
{
    return api(AdminPhotoAddUrl,{title:title},useHttp).sync();
}
/**
* 'AdminPhotoAddAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoAddAsync(title,useHttp)
{
    return api(AdminPhotoAddUrl,{title:title},useHttp);
}
var AdminPhotoDelUrl='/admin/photo/Del';
/**
* 'var result= await AdminPhotoDel(params);'
**/
function AdminPhotoDel(id,useHttp)
{
    return api(AdminPhotoDelUrl,{id:id},useHttp).sync();
}
/**
* 'AdminPhotoDelAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoDelAsync(id,useHttp)
{
    return api(AdminPhotoDelUrl,{id:id},useHttp);
}
var AdminPhotoSetDefaultUrl='/admin/photo/SetDefault';
/**
* 'var result= await AdminPhotoSetDefault(params);'
**/
function AdminPhotoSetDefault(id,useHttp)
{
    return api(AdminPhotoSetDefaultUrl,{id:id},useHttp).sync();
}
/**
* 'AdminPhotoSetDefaultAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoSetDefaultAsync(id,useHttp)
{
    return api(AdminPhotoSetDefaultUrl,{id:id},useHttp);
}
var AdminPhotoGetImageIDUrl='/admin/photo/GetImageID';
/**
* 'var result= await AdminPhotoGetImageID(params);'
**/
function AdminPhotoGetImageID(useHttp)
{
    return api(AdminPhotoGetImageIDUrl,{},useHttp).sync();
}
/**
* 'AdminPhotoGetImageIDAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoGetImageIDAsync(useHttp)
{
    return api(AdminPhotoGetImageIDUrl,{},useHttp);
}
var AdminPhotoUploadImageUrl='/admin/photo/UploadImage';
/**
* 'var result= await AdminPhotoUploadImage(params);'
**/
function AdminPhotoUploadImage(id,file,photoid,large,useHttp)
{
    return api(AdminPhotoUploadImageUrl,{id:id,file:file,photoid:photoid,large:large},useHttp).sync();
}
/**
* 'AdminPhotoUploadImageAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoUploadImageAsync(id,file,photoid,large,useHttp)
{
    return api(AdminPhotoUploadImageUrl,{id:id,file:file,photoid:photoid,large:large},useHttp);
}
var AdminPhotoDelItemUrl='/admin/photo/DelItem';
/**
* 'var result= await AdminPhotoDelItem(params);'
**/
function AdminPhotoDelItem(id,useHttp)
{
    return api(AdminPhotoDelItemUrl,{id:id},useHttp).sync();
}
/**
* 'AdminPhotoDelItemAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoDelItemAsync(id,useHttp)
{
    return api(AdminPhotoDelItemUrl,{id:id},useHttp);
}
var AdminPhotoGetUrl='/admin/photo/Get';
/**
* 'var result= await AdminPhotoGet(params);'
**/
function AdminPhotoGet(id,useHttp)
{
    return api(AdminPhotoGetUrl,{id:id},useHttp).sync();
}
/**
* 'AdminPhotoGetAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoGetAsync(id,useHttp)
{
    return api(AdminPhotoGetUrl,{id:id},useHttp);
}
var AdminPhotoListUrl='/admin/photo/List';
/**
* 'var result= await AdminPhotoList(params);'
**/
function AdminPhotoList(index,useHttp)
{
    return api(AdminPhotoListUrl,{index:index},useHttp).sync();
}
/**
* 'AdminPhotoListAsync(params).execute(function(result){},useHttp);'
**/
function AdminPhotoListAsync(index,useHttp)
{
    return api(AdminPhotoListUrl,{index:index},useHttp);
}
