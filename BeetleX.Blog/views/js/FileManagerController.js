/************************************************************************************
FastHttpApi javascript api Generator Copyright © henryfan 2018 email:henryfan@msn.com
https://github.com/IKende/FastHttpApi
**************************************************************************************/




/** 
创建文件夹 url 
**/
var FileManagerCreateFolderUrl = '/admin/files/createfolder';
/** 创建文件夹 'var result=await FileManagerCreateFolder(params)'
/* @param folder 当前目录
/* @param name 新建目录名称
/* @param useHttp only http request
/* @return 
**/
function FileManagerCreateFolder(folder, name, useHttp) {
    return api(FileManagerCreateFolderUrl, { folder: folder, name: name }, useHttp).sync();
}
/** 创建文件夹 'FileManagerCreateFolderAsync(params).execute(function(result){},useHttp)'
/* @param folder 当前目录
/* @param name 新建目录名称
/* @param useHttp only http request
/* @return 
**/
function FileManagerCreateFolderAsync(folder, name, useHttp) {
    return api(FileManagerCreateFolderUrl, { folder: folder, name: name }, useHttp);
}
/** 
上传文件信息 url 
**/
var FileManagerUploadFileUrl = '/admin/files/uploadfile';
/** 上传文件信息 'var result=await FileManagerUploadFile(params)'
/* @param folder 当前目录
/* @param info 文件信息
/* @param useHttp only http request
/* @return 
**/
function FileManagerUploadFile(folder, info, useHttp) {
    return api(FileManagerUploadFileUrl, { folder: folder, info: info }, useHttp, true).sync();
}
/** 上传文件信息 'FileManagerUploadFileAsync(params).execute(function(result){},useHttp)'
/* @param folder 当前目录
/* @param info 文件信息
/* @param useHttp only http request
/* @return 
**/
function FileManagerUploadFileAsync(folder, info, useHttp) {
    return api(FileManagerUploadFileUrl, { folder: folder, info: info }, useHttp, true);
}
/** 
删除资源 url 
**/
var FileManagerDeleteResourceUrl = '/admin/files/deleteresource';
/** 删除资源 'var result=await FileManagerDeleteResource(params)'
/* @param folder 当前目录
/* @param name 删除资源名称
/* @param file 是否文件
/* @param useHttp only http request
/* @return 
**/
function FileManagerDeleteResource(folder, name, file, useHttp) {
    return api(FileManagerDeleteResourceUrl, { folder: folder, name: name, file: file }, useHttp).sync();
}
/** 删除资源 'FileManagerDeleteResourceAsync(params).execute(function(result){},useHttp)'
/* @param folder 当前目录
/* @param name 删除资源名称
/* @param file 是否文件
/* @param useHttp only http request
/* @return 
**/
function FileManagerDeleteResourceAsync(folder, name, file, useHttp) {
    return api(FileManagerDeleteResourceUrl, { folder: folder, name: name, file: file }, useHttp);
}
/** 
获取目录资源信息 url 
**/
var FileManagerListUrl = '/admin/files/list';
/** 获取目录资源信息 'var result=await FileManagerList(params)'
/* @param folder 当前目录
/* @param useHttp only http request
/* @return 资源列表
**/
function FileManagerList(folder, useHttp) {
    return api(FileManagerListUrl, { folder: folder }, useHttp).sync();
}
/** 获取目录资源信息 'FileManagerListAsync(params).execute(function(result){},useHttp)'
/* @param folder 当前目录
/* @param useHttp only http request
/* @return 资源列表
**/
function FileManagerListAsync(folder, useHttp) {
    return api(FileManagerListUrl, { folder: folder }, useHttp);
}
