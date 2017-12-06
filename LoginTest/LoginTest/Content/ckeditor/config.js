/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */



CKEDITOR.editorConfig = function (config) {
    config.toolbar = 'MyToolbar';

    config.toolbar_MyToolbar =
        [
            //{ name: 'document', items: ['NewPage', 'Preview'] },
            //{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
            //{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
            //{
            //    name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'
            //        , 'Iframe']
            //},
            {
                name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'Iframe']
            },
            //'/',
            { name: 'styles', items: ['Styles', 'Format'] },
            { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
            { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
            { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
            //{ name: 'tools', items: ['Maximize', '-', 'About'] }
        ];
    //config.toolbar = [
    //    { name: 'clipboard', item: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] }
    //];
    // Define changes to default configuration here. For example:
    config.language = 'en';
    // config.uiColor = '#AADC6E';
    //Chỉ ra ngôn ngữ
    //config.language = 'vi';
    //Cấu hình đường dẫn các loại tệp tin khi finder
    config.filebrowserBrowserUrl = "/Content/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Content/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashUrl = "/Content/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File";
    config.filebrowserImageUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    CKFinder.setupCKEditor(null, "/Content/ckfinder/");
};

//CKEDITOR.on('dialogDefinition', function (ev) {
//    // Take the dialog name and its definition from the event data.
//    var dialogName = ev.data.name;
//    var dialogDefinition = ev.data.definition;

//    // Check if the definition is from the dialog window you are interested in (the "Link" dialog window).
//    if (dialogName == 'link') {
//        // Get a reference to the "Link Info" tab.
//        //var infoTab = dialogDefinition.getContents('info');

//        //// Set the default value for the URL field.
//        //var urlField = infoTab.get('url');
//        //urlField['default'] = 'www.example.com';
//        var infoTab = dialogDefinition.getContents('info');

//        // Set the default value for the URL field.
//        var urlField = infoTab.get('url');
//        urlField['default'] = 'www.example.com';
//    }
//});

//CKEDITOR.on('dialogDefinition', function (ev) {
//    // Take the dialog name and its definition from the event data.
//    var dialogName = ev.data.name;
//    var dialogDefinition = ev.data.definition;

//    // Check if the definition is from the dialog window you are interested in (the "Link" dialog window).
//    if (dialogName == 'image') {
//        // Get a reference to the "Link Info" tab.
//        var infoTab = dialogDefinition.getContents('info');

//        // Set the default value for the URL field.
//        var urlField = infoTab.get('url');
//        urlField['default'] = 'hahaha';
//    }
//});

