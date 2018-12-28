/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var AdminCategoryAddUrl='/admin/category/Add';
/**
* 'var result= await AdminCategoryAdd(params);'
**/
function AdminCategoryAdd(name,remark,useHttp)
{
    return api(AdminCategoryAddUrl,{name:name,remark:remark},useHttp,true).sync();
}
/**
* 'AdminCategoryAddAsync(params).execute(function(result){},useHttp);'
**/
function AdminCategoryAddAsync(name,remark,useHttp)
{
    return api(AdminCategoryAddUrl,{name:name,remark:remark},useHttp,true);
}
var AdminCategoryOrderUrl='/admin/category/Order';
/**
* 'var result= await AdminCategoryOrder(params);'
**/
function AdminCategoryOrder(id,up,useHttp)
{
    return api(AdminCategoryOrderUrl,{id:id,up:up},useHttp).sync();
}
/**
* 'AdminCategoryOrderAsync(params).execute(function(result){},useHttp);'
**/
function AdminCategoryOrderAsync(id,up,useHttp)
{
    return api(AdminCategoryOrderUrl,{id:id,up:up},useHttp);
}
var AdminCategoryDelUrl='/admin/category/Del';
/**
* 'var result= await AdminCategoryDel(params);'
**/
function AdminCategoryDel(id,useHttp)
{
    return api(AdminCategoryDelUrl,{id:id},useHttp).sync();
}
/**
* 'AdminCategoryDelAsync(params).execute(function(result){},useHttp);'
**/
function AdminCategoryDelAsync(id,useHttp)
{
    return api(AdminCategoryDelUrl,{id:id},useHttp);
}
var AdminCategoryListUrl='/admin/category/List';
/**
* 'var result= await AdminCategoryList(params);'
**/
function AdminCategoryList(useHttp)
{
    return api(AdminCategoryListUrl,{},useHttp).sync();
}
/**
* 'AdminCategoryListAsync(params).execute(function(result){},useHttp);'
**/
function AdminCategoryListAsync(useHttp)
{
    return api(AdminCategoryListUrl,{},useHttp);
}
