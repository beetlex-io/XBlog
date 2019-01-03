/*
Navicat SQLite Data Transfer

Source Server         : beetlexBlog
Source Server Version : 30623
Source Host           : localhost:0

Target Server Type    : SQLite
Target Server Version : 30623
File Encoding         : 65001

Date: 2019-01-03 15:05:29
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."Blog"
-- ----------------------------
DROP TABLE "main"."Blog";
CREATE TABLE "Blog" (
"ID"  INTEGER,
"Title"  TEXT,
"Top"  INTEGER,
"Content"  TEXT,
"Summary"  TEXT,
"Category"  TEXT,
"CategoryID"  INTEGER,
"Tags"  TEXT,
"SourceUrl"  TEXT,
"CreateTime"  INTEGER,
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of Blog
-- ----------------------------

-- ----------------------------
-- Table structure for "main"."Category"
-- ----------------------------
DROP TABLE "main"."Category";
CREATE TABLE "Category" (
"ID"  INTEGER,
"Name"  TEXT,
"Remark"  TEXT,
"OrderBy"  INTEGER,
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of Category
-- ----------------------------

-- ----------------------------
-- Table structure for "main"."Comment"
-- ----------------------------
DROP TABLE "main"."Comment";
CREATE TABLE "Comment" (
"ID"  INTEGER,
"NickName"  TEXT,
"BlogID"  INTEGER,
"Content"  TEXT,
"CreateTime"  INTEGER,
"HeadUrl"  TEXT,
"UserID"  TEXT,
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of Comment
-- ----------------------------


-- ----------------------------
-- Table structure for "main"."Option"
-- ----------------------------
DROP TABLE "main"."Option";
CREATE TABLE "Option" (
"Name"  TEXT,
"Value"  TEXT,
PRIMARY KEY ("Name")
);

-- ----------------------------
-- Records of Option
-- ----------------------------


-- ----------------------------
-- Table structure for "main"."Photo"
-- ----------------------------
DROP TABLE "main"."Photo";
CREATE TABLE "Photo" (
"ID"  INTEGER,
"Title"  TEXT,
"CreateTime"  INTEGER,
"SmallUrl"  TEXT,
"LargeUrl"  TEXT,
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of Photo
-- ----------------------------


-- ----------------------------
-- Table structure for "main"."PhotoItem"
-- ----------------------------
DROP TABLE "main"."PhotoItem";
CREATE TABLE "PhotoItem" (
"ID"  TEXT,
"PhotoID"  INTEGER,
"LargeUrl"  TEXT,
"SmallUrl"  TEXT,
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of PhotoItem
-- ----------------------------


-- ----------------------------
-- Table structure for "main"."RefreshBlog"
-- ----------------------------
DROP TABLE "main"."RefreshBlog";
CREATE TABLE "RefreshBlog" (
"BlogID"  INTEGER,
"CreateTime"  INTEGER,
"Status"  INTEGER
);

-- ----------------------------
-- Records of RefreshBlog
-- ----------------------------

-- ----------------------------
-- Table structure for "main"."Sequence"
-- ----------------------------
DROP TABLE "main"."Sequence";
CREATE TABLE "Sequence" (
"Key"  TEXT,
"Value"  INTEGER,
PRIMARY KEY ("Key")
);


