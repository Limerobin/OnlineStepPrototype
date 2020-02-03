const Page = require("../models/PageModel");
const { body, validationResult } = require("express-validator");
const { sanitizeBody } = require("express-validator");

var mongoose = require("mongoose");
const apiResponse = require("../helpers/apiResponse");

// Page Schema
function PageData(data) {
    this.type = data.type;
    this.title = data.title;
    this.author = data.author;
    this.content = data.content;

}

exports.getPageList = [
    function(req, res) {
        try {
            Page.find({}, "").then((page) => {
                if (page.length > 0) {
                    return apiResponse.successResponseWithData(res, "Operation success", page);
                } else {
                    return apiResponse.successResponseWithData(res, "Operation success", []);
                }
            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.getPage = [
    function (req, res) {
        //if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
        //    return apiResponse.successResponseWithData(res, "Operation success", {});
        //}
        try {
            Page.findOne({ _id: req.params.id }, "_id type title author").then((page) => {
                if (Page !== null) {
                    let pageData = new PageData(Page);
                    return apiResponse.successResponseWithData(res, "Operation success.", page);
                } else {
                    return apiResponse.successResponseWithData(res, "Operation success", {});
                }
            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];


exports.addPage = [
    body("type", "Type must not be empty.").isLength({ min: 1 }).trim(),
    body("title", "Title must not be empty.").isLength({ min: 1 }).trim(),
    body("author", "Author must not be empty").isLength({ min: 1 }).trim()
    ,
    sanitizeBody("*").escape(),
    (req, res) => {
        try {
            console.log(req.body);
            const errors = validationResult(req);
            var page = new Page(
                {
                    type: req.body.type,
                    title: req.body.title,
                    author: req.body.author,
                    content: req.body.content
                });


            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                //Save Question.
                page.save(function (err) {
                    if (err) { return apiResponse.ErrorResponse(res, err); }
                    let pageData = new PageData(page);
                    return apiResponse.successResponseWithData(res, "Page add Successfully.", pageData);
                });
            }
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.updatePage = [
    body("type", "Type must not be empty.").isLength({ min: 1 }).trim(),
    body("title", "Title must not be empty.").isLength({ min: 1 }).trim(),
    body("author", "Author must not be empty").isLength({ min: 1 }).trim()
    ,
    sanitizeBody("*").escape(),
    (req, res) => {
        try {
            const errors = validationResult(req);
            var page = new BlankPage(
                {
                    type: req.body.type,
                    title: req.body.title,
                    author: req.body.author,
                    _id: req.params.id
                });

            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
                    return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
                } else {
                    Page.findById(req.params.id, function (err, foundPage) {
                        if (foundPage === null) {
                            return apiResponse.notFoundResponse(res, "Page not exists with this id");
                        }  else {
                                //update page.
                                Page.findByIdAndUpdate(req.params.id, page, {}, function (err) {
                                    if (err) {
                                        return apiResponse.ErrorResponse(res, err);
                                    } else {
                                        let pageData = new PageData(page);
                                        return apiResponse.successResponseWithData(res, "Page update Success.", pageData);
                                    }
                                });
                            }
                        
                    });
                }
            }
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.deletePage = [
    function (req, res) {
        if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
            return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
        }
        try {
            Page.findById(req.params.id, function (err, foundPage) {
                if (foundPage === null) {
                    return apiResponse.notFoundResponse(res, "Page not exists with this id");
                } else  {
                        //delete page.
                        Page.findByIdAndRemove(req.params.id, function (err) {
                            if (err) {
                                return apiResponse.ErrorResponse(res, err);
                            } else {
                                return apiResponse.successResponse(res, "Page delete Success.");
                            }
                        });
                    }
                
            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];