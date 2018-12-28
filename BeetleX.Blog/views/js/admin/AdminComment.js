/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var AdminCommentListUrl='/admin/comment/List';
/**
* 'var result= await AdminCommentList(params);'
**/
function AdminCommentList(index,useHttp)
{
    return api(AdminCommentListUrl,{index:index},useHttp).sync();
}
/**
* 'AdminCommentListAsync(params).execute(function(result){},useHttp);'
**/
function AdminCommentListAsync(index,useHttp)
{
    return api(AdminCommentListUrl,{index:index},useHttp);
}
var AdminCommentDelUrl='/admin/comment/Del';
/**
* 'var result= await AdminCommentDel(params);'
**/
function AdminCommentDel(id,useHttp)
{
    return api(AdminCommentDelUrl,{id:id},useHttp).sync();
}
/**
* 'AdminCommentDelAsync(params).execute(function(result){},useHttp);'
**/
function AdminCommentDelAsync(id,useHttp)
{
    return api(AdminCommentDelUrl,{id:id},useHttp);
}
