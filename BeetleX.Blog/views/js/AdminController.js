/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




/** 
文档列表 url 
**/
var AdminListDocUrl = '/admin/listdoc';
/** 文档列表 'var result=await AdminListDoc(params)'
/* @param index 文件分页索引
/* @param useHttp only http request
/* @return { Index = index, Pages = pages, Items = items }
**/
function AdminListDoc(index, useHttp) {
    return api(AdminListDocUrl, { index: index }, useHttp).sync();
}
/** 文档列表 'AdminListDocAsync(params).execute(function(result){},useHttp)'
/* @param index 文件分页索引
/* @param useHttp only http request
/* @return { Index = index, Pages = pages, Items = items }
**/
function AdminListDocAsync(index, useHttp) {
    return api(AdminListDocUrl, { index: index }, useHttp);
}
/** 
编辑文档 url 
**/
var AdminEditDocUrl = '/admin/editdoc';
/** 编辑文档 'var result=await AdminEditDoc(params)'
/* @param id 文档ID
/* @param tag 文档分类
/* @param document 文档内容{Title:'',Remark:''}
/* @param useHttp only http request
/* @return true
**/
function AdminEditDoc(id, tag, document, useHttp) {
    return api(AdminEditDocUrl, { id: id, tag: tag, document: document }, useHttp, true).sync();
}
/** 编辑文档 'AdminEditDocAsync(params).execute(function(result){},useHttp)'
/* @param id 文档ID
/* @param tag 文档分类
/* @param document 文档内容{Title:'',Remark:''}
/* @param useHttp only http request
/* @return true
**/
function AdminEditDocAsync(id, tag, document, useHttp) {
    return api(AdminEditDocUrl, { id: id, tag: tag, document: document }, useHttp, true);
}
/** 
添加文档 url 
**/
var AdminAddDocUrl = '/admin/adddoc';
/** 添加文档 'var result=await AdminAddDoc(params)'
/* @param document 文档内容{Title:'',Remark:''}
/* @param tag 文档分类
/* @param useHttp only http request
/* @return bool
**/
function AdminAddDoc(tag, document, useHttp) {
    return api(AdminAddDocUrl, { tag: tag, document: document }, useHttp, true).sync();
}
/** 添加文档 'AdminAddDocAsync(params).execute(function(result){},useHttp)'
/* @param document 文档内容{Title:'',Remark:''}
/* @param tag 文档分类
/* @param useHttp only http request
/* @return bool
**/
function AdminAddDocAsync(tag, document, useHttp) {
    return api(AdminAddDocUrl, { tag: tag, document: document }, useHttp, true);
}
/** 
获取文档 url 
**/
var AdminGetDocUrl = '/admin/getdoc';
/** 获取文档 'var result=await AdminGetDoc(params)'
/* @param id 文档ID
/* @param useHttp only http request
/* @return 
**/
function AdminGetDoc(id, useHttp) {
    return api(AdminGetDocUrl, { id: id }, useHttp).sync();
}
/** 获取文档 'AdminGetDocAsync(params).execute(function(result){},useHttp)'
/* @param id 文档ID
/* @param useHttp only http request
/* @return 
**/
function AdminGetDocAsync(id, useHttp) {
    return api(AdminGetDocUrl, { id: id }, useHttp);
}
/** 
删除文档 url 
**/
var AdminDelDocUrl = '/admin/deldoc';
/** 删除文档 'var result=await AdminDelDoc(params)'
/* @param id [id,id,id]
/* @param useHttp only http request
/* @return 
**/
function AdminDelDoc(id, useHttp) {
    return api(AdminDelDocUrl, { id: id }, useHttp, true).sync();
}
/** 删除文档 'AdminDelDocAsync(params).execute(function(result){},useHttp)'
/* @param id [id,id,id]
/* @param useHttp only http request
/* @return 
**/
function AdminDelDocAsync(id, useHttp) {
    return api(AdminDelDocUrl, { id: id }, useHttp, true);
}
var AdminAddBlockUrl = '/admin/addblock';
/**
* 'var result= await AdminAddBlock(params);'
**/
function AdminAddBlock(block, useHttp) {
    return api(AdminAddBlockUrl, { block: block }, useHttp, true).sync();
}
/**
* 'AdminAddBlockAsync(params).execute(function(result){},useHttp);'
**/
function AdminAddBlockAsync(block, useHttp) {
    return api(AdminAddBlockUrl, { block: block }, useHttp, true);
}
var AdminEditBlockUrl = '/admin/editblock';
/**
* 'var result= await AdminEditBlock(params);'
**/
function AdminEditBlock(id, block, useHttp) {
    return api(AdminEditBlockUrl, { id: id, block: block }, useHttp, true).sync();
}
/**
* 'AdminEditBlockAsync(params).execute(function(result){},useHttp);'
**/
function AdminEditBlockAsync(id, block, useHttp) {
    return api(AdminEditBlockUrl, { id: id, block: block }, useHttp, true);
}
var AdminGetBlockUrl = '/admin/getblock';
/**
* 'var result= await AdminGetBlock(params);'
**/
function AdminGetBlock(id, useHttp) {
    return api(AdminGetBlockUrl, { id: id }, useHttp).sync();
}
/**
* 'AdminGetBlockAsync(params).execute(function(result){},useHttp);'
**/
function AdminGetBlockAsync(id, useHttp) {
    return api(AdminGetBlockUrl, { id: id }, useHttp);
}
/** 
 url 
**/
var AdminListBlockUrl = '/admin/listblock';
/**  'var result=await AdminListBlock(params)'
/* @param ids id,id,id
/* @param useHttp only http request
/* @return 
**/
function AdminListBlock(ids, useHttp) {
    return api(AdminListBlockUrl, { ids: ids }, useHttp).sync();
}
/**  'AdminListBlockAsync(params).execute(function(result){},useHttp)'
/* @param ids id,id,id
/* @param useHttp only http request
/* @return 
**/
function AdminListBlockAsync(ids, useHttp) {
    return api(AdminListBlockUrl, { ids: ids }, useHttp);
}
/** 
 url 
**/
var AdminDelBlockUrl = '/admin/delblock';
/**  'var result=await AdminDelBlock(params)'
/* @param ids id,id,id
/* @param useHttp only http request
/* @return 
**/
function AdminDelBlock(ids, useHttp) {
    return api(AdminDelBlockUrl, { ids: ids }, useHttp).sync();
}
/**  'AdminDelBlockAsync(params).execute(function(result){},useHttp)'
/* @param ids id,id,id
/* @param useHttp only http request
/* @return 
**/
function AdminDelBlockAsync(ids, useHttp) {
    return api(AdminDelBlockUrl, { ids: ids }, useHttp);
}
var AdminListCommentUrl = '/admin/listcomment';
/**
* 'var result= await AdminListComment(params);'
**/
function AdminListComment(document, useHttp) {
    return api(AdminListCommentUrl, { document: document }, useHttp).sync();
}
/**
* 'AdminListCommentAsync(params).execute(function(result){},useHttp);'
**/
function AdminListCommentAsync(document, useHttp) {
    return api(AdminListCommentUrl, { document: document }, useHttp);
}
var AdminDelDocCommentUrl = '/admin/deldoccomment';
/**
* 'var result= await AdminDelDocComment(params);'
**/
function AdminDelDocComment(id, useHttp) {
    return api(AdminDelDocCommentUrl, { id: id }, useHttp).sync();
}
/**
* 'AdminDelDocCommentAsync(params).execute(function(result){},useHttp);'
**/
function AdminDelDocCommentAsync(id, useHttp) {
    return api(AdminDelDocCommentUrl, { id: id }, useHttp);
}
var AdminGetTagUrl = '/admin/gettag';
/**
* 'var result= await AdminGetTag(params);'
**/
function AdminGetTag(id, useHttp) {
    return api(AdminGetTagUrl, { id: id }, useHttp).sync();
}
/**
* 'AdminGetTagAsync(params).execute(function(result){},useHttp);'
**/
function AdminGetTagAsync(id, useHttp) {
    return api(AdminGetTagUrl, { id: id }, useHttp);
}
var AdminListTagUrl = '/admin/listtag';
/**
* 'var result= await AdminListTag(params);'
**/
function AdminListTag(useHttp) {
    return api(AdminListTagUrl, {}, useHttp).sync();
}
/**
* 'AdminListTagAsync(params).execute(function(result){},useHttp);'
**/
function AdminListTagAsync(useHttp) {
    return api(AdminListTagUrl, {}, useHttp);
}
var AdminDeleteTagUrl = '/admin/deletetag';
/**
* 'var result= await AdminDeleteTag(params);'
**/
function AdminDeleteTag(ids, useHttp) {
    return api(AdminDeleteTagUrl, { ids: ids }, useHttp).sync();
}
/**
* 'AdminDeleteTagAsync(params).execute(function(result){},useHttp);'
**/
function AdminDeleteTagAsync(ids, useHttp) {
    return api(AdminDeleteTagUrl, { ids: ids }, useHttp);
}
var AdminEditTagUrl = '/admin/edittag';
/**
* 'var result= await AdminEditTag(params);'
**/
function AdminEditTag(id, title, remark, useHttp) {
    return api(AdminEditTagUrl, { id: id, title: title, remark: remark }, useHttp).sync();
}
/**
* 'AdminEditTagAsync(params).execute(function(result){},useHttp);'
**/
function AdminEditTagAsync(id, title, remark, useHttp) {
    return api(AdminEditTagUrl, { id: id, title: title, remark: remark }, useHttp);
}
var AdminAddTagUrl = '/admin/addtag';
/**
* 'var result= await AdminAddTag(params);'
**/
function AdminAddTag(title, remark, useHttp) {
    return api(AdminAddTagUrl, { title: title, remark: remark }, useHttp).sync();
}
/**
* 'AdminAddTagAsync(params).execute(function(result){},useHttp);'
**/
function AdminAddTagAsync(title, remark, useHttp) {
    return api(AdminAddTagUrl, { title: title, remark: remark }, useHttp);
}
var AdminAddBlogUrl = '/admin/addblog';
/**
* 'var result= await AdminAddBlog(params);'
**/
function AdminAddBlog(blogInfo, useHttp) {
    return api(AdminAddBlogUrl, { blogInfo: blogInfo }, useHttp, true).sync();
}
/**
* 'AdminAddBlogAsync(params).execute(function(result){},useHttp);'
**/
function AdminAddBlogAsync(blogInfo, useHttp) {
    return api(AdminAddBlogUrl, { blogInfo: blogInfo }, useHttp, true);
}
var AdminEditBlogUrl = '/admin/editblog';
/**
* 'var result= await AdminEditBlog(params);'
**/
function AdminEditBlog(id, blogInfo, useHttp) {
    return api(AdminEditBlogUrl, { id: id, blogInfo: blogInfo }, useHttp, true).sync();
}
/**
* 'AdminEditBlogAsync(params).execute(function(result){},useHttp);'
**/
function AdminEditBlogAsync(id, blogInfo, useHttp) {
    return api(AdminEditBlogUrl, { id: id, blogInfo: blogInfo }, useHttp, true);
}
var AdminDelBlogUrl = '/admin/delblog';
/**
* 'var result= await AdminDelBlog(params);'
**/
function AdminDelBlog(ids, useHttp) {
    return api(AdminDelBlogUrl, { ids: ids }, useHttp).sync();
}
/**
* 'AdminDelBlogAsync(params).execute(function(result){},useHttp);'
**/
function AdminDelBlogAsync(ids, useHttp) {
    return api(AdminDelBlogUrl, { ids: ids }, useHttp);
}
var AdminGetBlogUrl = '/admin/getblog';
/**
* 'var result= await AdminGetBlog(params);'
**/
function AdminGetBlog(id, useHttp) {
    return api(AdminGetBlogUrl, { id: id }, useHttp).sync();
}
/**
* 'AdminGetBlogAsync(params).execute(function(result){},useHttp);'
**/
function AdminGetBlogAsync(id, useHttp) {
    return api(AdminGetBlogUrl, { id: id }, useHttp);
}
var AdminListBlogUrl = '/admin/listblog';
/**
* 'var result= await AdminListBlog(params);'
**/
function AdminListBlog(index, useHttp) {
    return api(AdminListBlogUrl, { index: index }, useHttp).sync();
}
/**
* 'AdminListBlogAsync(params).execute(function(result){},useHttp);'
**/
function AdminListBlogAsync(index, useHttp) {
    return api(AdminListBlogUrl, { index: index }, useHttp);
}
