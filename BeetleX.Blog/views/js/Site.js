/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




var SiteGetTitleAndMenuUrl = '/GetTitleAndMenu';
/**
* 'var result= await SiteGetTitleAndMenu(params);'
**/
function SiteGetTitleAndMenu(useHttp) {
    return api(SiteGetTitleAndMenuUrl, {}, useHttp).sync();
}
/**
* 'SiteGetTitleAndMenuAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetTitleAndMenuAsync(useHttp) {
    return api(SiteGetTitleAndMenuUrl, {}, useHttp);
}
var SiteGetTagsUrl = '/GetTags';
/**
* 'var result= await SiteGetTags(params);'
**/
function SiteGetTags(top, useHttp) {
    return api(SiteGetTagsUrl, { top: top }, useHttp).sync();
}
/**
* 'SiteGetTagsAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetTagsAsync(top, useHttp) {
    return api(SiteGetTagsUrl, { top: top }, useHttp);
}
var SiteGetAllTagsUrl = '/GetAllTags';
/**
* 'var result= await SiteGetAllTags(params);'
**/
function SiteGetAllTags(useHttp) {
    return api(SiteGetAllTagsUrl, {}, useHttp).sync();
}
/**
* 'SiteGetAllTagsAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetAllTagsAsync(useHttp) {
    return api(SiteGetAllTagsUrl, {}, useHttp);
}
var SiteTopCommentUrl = '/TopComment';
/**
* 'var result= await SiteTopComment(params);'
**/
function SiteTopComment(useHttp) {
    return api(SiteTopCommentUrl, {}, useHttp).sync();
}
/**
* 'SiteTopCommentAsync(params).execute(function(result){},useHttp);'
**/
function SiteTopCommentAsync(useHttp) {
    return api(SiteTopCommentUrl, {}, useHttp);
}
var SiteTopBlogUrl = '/TopBlog';
/**
* 'var result= await SiteTopBlog(params);'
**/
function SiteTopBlog(useHttp) {
    return api(SiteTopBlogUrl, {}, useHttp).sync();
}
/**
* 'SiteTopBlogAsync(params).execute(function(result){},useHttp);'
**/
function SiteTopBlogAsync(useHttp) {
    return api(SiteTopBlogUrl, {}, useHttp);
}
var SiteNewBlogUrl = '/NewBlog';
/**
* 'var result= await SiteNewBlog(params);'
**/
function SiteNewBlog(useHttp) {
    return api(SiteNewBlogUrl, {}, useHttp).sync();
}
/**
* 'SiteNewBlogAsync(params).execute(function(result){},useHttp);'
**/
function SiteNewBlogAsync(useHttp) {
    return api(SiteNewBlogUrl, {}, useHttp);
}
var SiteGetAboutUrl = '/GetAbout';
/**
* 'var result= await SiteGetAbout(params);'
**/
function SiteGetAbout(useHttp) {
    return api(SiteGetAboutUrl, {}, useHttp).sync();
}
/**
* 'SiteGetAboutAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetAboutAsync(useHttp) {
    return api(SiteGetAboutUrl, {}, useHttp);
}
var SiteListCommintUrl = '/ListCommint';
/**
* 'var result= await SiteListCommint(params);'
**/
function SiteListCommint(id, useHttp) {
    return api(SiteListCommintUrl, { id: id }, useHttp).sync();
}
/**
* 'SiteListCommintAsync(params).execute(function(result){},useHttp);'
**/
function SiteListCommintAsync(id, useHttp) {
    return api(SiteListCommintUrl, { id: id }, useHttp);
}
var SiteGetPhotoUrl = '/GetPhoto';
/**
* 'var result= await SiteGetPhoto(params);'
**/
function SiteGetPhoto(id, useHttp) {
    return api(SiteGetPhotoUrl, { id: id }, useHttp).sync();
}
/**
* 'SiteGetPhotoAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetPhotoAsync(id, useHttp) {
    return api(SiteGetPhotoUrl, { id: id }, useHttp);
}
var SiteListPhotoUrl = '/ListPhoto';
/**
* 'var result= await SiteListPhoto(params);'
**/
function SiteListPhoto(index, useHttp) {
    return api(SiteListPhotoUrl, { index: index }, useHttp).sync();
}
/**
* 'SiteListPhotoAsync(params).execute(function(result){},useHttp);'
**/
function SiteListPhotoAsync(index, useHttp) {
    return api(SiteListPhotoUrl, { index: index }, useHttp);
}
var SiteCommintUrl = '/Commint';
/**
* 'var result= await SiteCommint(params);'
**/
function SiteCommint(id, nickName, content, useHttp) {
    return api(SiteCommintUrl, { id: id, nickName: nickName, content: content }, useHttp, true).sync();
}
/**
* 'SiteCommintAsync(params).execute(function(result){},useHttp);'
**/
function SiteCommintAsync(id, nickName, content, useHttp) {
    return api(SiteCommintUrl, { id: id, nickName: nickName, content: content }, useHttp, true);
}
var SiteGetBlogUrl = '/GetBlog';
/**
* 'var result= await SiteGetBlog(params);'
**/
function SiteGetBlog(id, useHttp) {
    return api(SiteGetBlogUrl, { id: id }, useHttp).sync();
}
/**
* 'SiteGetBlogAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetBlogAsync(id, useHttp) {
    return api(SiteGetBlogUrl, { id: id }, useHttp);
}
var SiteGetServerInfoUrl = '/GetServerInfo';
/**
* 'var result= await SiteGetServerInfo(params);'
**/
function SiteGetServerInfo(useHttp) {
    return api(SiteGetServerInfoUrl, {}, useHttp).sync();
}
/**
* 'SiteGetServerInfoAsync(params).execute(function(result){},useHttp);'
**/
function SiteGetServerInfoAsync(useHttp) {
    return api(SiteGetServerInfoUrl, {}, useHttp);
}
var SiteSearchUrl = '/Search';
/**
* 'var result= await SiteSearch(params);'
**/
function SiteSearch(cate, tag, query, index, useHttp) {
    return api(SiteSearchUrl, { cate: cate, tag: tag, query: query, index: index }, useHttp).sync();
}
/**
* 'SiteSearchAsync(params).execute(function(result){},useHttp);'
**/
function SiteSearchAsync(cate, tag, query, index, useHttp) {
    return api(SiteSearchUrl, { cate: cate, tag: tag, query: query, index: index }, useHttp);
}
