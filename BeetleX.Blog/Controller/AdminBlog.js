/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var AdminBlogModifyUrl='/admin/blog/Modify';
/**
* 'var result= await AdminBlogModify(params);'
**/
function AdminBlogModify(id,title,top,tag,category,sourceUrl,content,summary,useHttp)
{
    return api(AdminBlogModifyUrl,{id:id,title:title,top:top,tag:tag,category:category,sourceUrl:sourceUrl,content:content,summary:summary},useHttp,true).sync();
}
/**
* 'AdminBlogModifyAsync(params).execute(function(result){},useHttp);'
**/
function AdminBlogModifyAsync(id,title,top,tag,category,sourceUrl,content,summary,useHttp)
{
    return api(AdminBlogModifyUrl,{id:id,title:title,top:top,tag:tag,category:category,sourceUrl:sourceUrl,content:content,summary:summary},useHttp,true);
}
var AdminBlogAllSyncToESUrl='/admin/blog/AllSyncToES';
/**
* 'var result= await AdminBlogAllSyncToES(params);'
**/
function AdminBlogAllSyncToES(useHttp)
{
    return api(AdminBlogAllSyncToESUrl,{},useHttp).sync();
}
/**
* 'AdminBlogAllSyncToESAsync(params).execute(function(result){},useHttp);'
**/
function AdminBlogAllSyncToESAsync(useHttp)
{
    return api(AdminBlogAllSyncToESUrl,{},useHttp);
}
var AdminBlogDeleteUrl='/admin/blog/Delete';
/**
* 'var result= await AdminBlogDelete(params);'
**/
function AdminBlogDelete(id,useHttp)
{
    return api(AdminBlogDeleteUrl,{id:id},useHttp,true).sync();
}
/**
* 'AdminBlogDeleteAsync(params).execute(function(result){},useHttp);'
**/
function AdminBlogDeleteAsync(id,useHttp)
{
    return api(AdminBlogDeleteUrl,{id:id},useHttp,true);
}
var AdminBlogGetUrl='/admin/blog/Get';
/**
* 'var result= await AdminBlogGet(params);'
**/
function AdminBlogGet(id,useHttp)
{
    return api(AdminBlogGetUrl,{id:id},useHttp).sync();
}
/**
* 'AdminBlogGetAsync(params).execute(function(result){},useHttp);'
**/
function AdminBlogGetAsync(id,useHttp)
{
    return api(AdminBlogGetUrl,{id:id},useHttp);
}
var AdminBlogListUrl='/admin/blog/List';
/**
* 'var result= await AdminBlogList(params);'
**/
function AdminBlogList(category,index,useHttp)
{
    return api(AdminBlogListUrl,{category:category,index:index},useHttp).sync();
}
/**
* 'AdminBlogListAsync(params).execute(function(result){},useHttp);'
**/
function AdminBlogListAsync(category,index,useHttp)
{
    return api(AdminBlogListUrl,{category:category,index:index},useHttp);
}
