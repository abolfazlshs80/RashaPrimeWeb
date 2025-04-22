       // This sample still does not showcase all CKEditor&nbsp;5 features (!)
            // Visit https://ckeditor.com/docs/ckeditor5/latest/features/index.html to browse all the features.


// تابعی برای اعمال تغییرات



function applyChanges() {
    // دسترسی به المان‌های با کلاس مشترک
    const editors = document.querySelectorAll('.editor');


    editors.forEach(editor => {
        CKEDITOR.ClassicEditor.create(editor, {
            alignment: {
                options: ['left', 'right']
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/toolbar/toolbar.html#extended-toolbar-configuration-format
            toolbar: {
                items: [
                    'exportPDF', 'exportWord', '|',
                    'findAndReplace', 'selectAll', '|',
                    'heading', '|',
                    'bold', 'italic', 'strikethrough', 'underline', 'code', 'subscript', 'superscript', 'removeFormat', '|',
                    'bulletedList', 'numberedList', 'todoList', '|',
                    'outdent', 'indent', '|',
                    'undo', 'redo',
                    '-',
                    'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
                    'alignment', '|',
                    'link', 'insertImage', 'blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
                    'specialCharacters', 'horizontalLine', 'pageBreak', '|',
                    'textPartLanguage', '|',
                    'sourceEditing'
                ],
                shouldNotGroupWhenFull: true
            },
            // Changing the language of the interface requires loading the language file using the <script> tag.
            language: 'fa',
            list: {
                properties: {
                    styles: true,
                    startIndex: true,
                    reversed: true
                }
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/headings.html#configuration
            heading: {
                options: [
                    { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                    { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                    { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                    { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                    { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                    { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                    { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                ]
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/editor-placeholder.html#using-the-editor-configuration
            placeholder: 'Welcome to CKEditor&nbsp;5!',
            // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-family-feature
            fontFamily: {
                options: [ 'B-Arabics-Style_YasDL' ,'B-Arash_YasDL' ,'B-Aria_YasDL' ,'B-Arshia_YasDL' ,'B-Aseman-Italic_YasDL' ,'B-Aseman_YasDL' ,'B-Badkonak_YasDL' ,'B-Badr-Bold_YasDL' ,'B-Badr_YasDL' ,'B-Baran-Italic_YasDL' ,'B-Baran-Outline-Italic_YasDL' ,'B-Baran-Outline_YasDL' ,'B-Baran_YasDL' ,'B-Bardiya-Bold_YasDL' ,'B-Bardiya_YasDL' ,'B-Cheshmeh-Bold_YasDL' ,'B-Cheshmeh_YasDL' ,'B-Chini_YasDL' ,'B-Compset-Bold_YasDL' ,'B-Compset_YasDL' ,'B-Davat_YasDL' ,'B-Elham_YasDL' ,'B-Elm-Bold_YasDL' ,'B-Elm-Italic_YasDL' ,'B-Elm_YasDL' ,'B-Esfehan-Bold_YasDL' ,'B-Fantezy_YasDL' ,'B-Farnaz_YasDL' ,'B-Ferdosi_YasDL' ,'B-Haleh-Bold_YasDL' ,'B-Haleh_YasDL' ,'B-Hamid_YasDL' ,'B-Helal_YasDL' ,'B-Homa_YasDL' ,'B-Jadid-Bold_YasDL' ,'B-Jalal-Bold_YasDL' ,'B-Jalal_YasDL' ,'B-Johar_YasDL' ,'B-Kaj_YasDL' ,'B-Kamran-Bold_YasDL' ,'B-Kamran-Outline_YasDL' ,'B-Kamran_YasDL' ,'B-Karim-Bold_YasDL' ,'B-Karim_YasDL' ,'B-Kaveh_YasDL' ,'B-Kidnap_YasDL' ,'B-Koodak-Bold_YasDL' ,'B-Koodak-Outline_YasDL' ,'B-Kourosh_YasDL' ,'B-Lotus-Bold_YasDL' ,'B-Lotus_YasDL' ,'B-Mahsa_YasDL' ,'B-Mah_YasDL' ,'B-Majid-Shadow_YasDL' ,'B-Mashhad-Bold-Italic_YasDL' ,'B-Mashhad-Bold_YasDL' ,'B-Mashhad-Italic_YasDL' ,'B-Mashhad_YasDL' ,'B-Masjed_YasDL' ,'B-Medad_YasDL' ,'B-Mehr-Bold_YasDL' ,'B-Mitra-Bold_YasDL' ,'B-Mitra_YasDL' ,'B-Moj_YasDL' ,'B-Morvarid_YasDL' ,'B-Narenj_YasDL' ,'B-Narm_YasDL' ,'B-Nasim-Bold_YasDL' ,'B-Nazanin-Bold_YasDL' ,'B-Nazanin-Outline_YasDL' ,'B-Nazanin_YasDL' ,'B-Niki-Bold_YasDL' ,'B-Niki-Border-Italic_YasDL' ,'B-Niki-Outline-Italic_YasDL' ,'B-Niki-Outline_YasDL' ,'B-Niki-Shadow-Italic_YasDL' ,'B-Niki-Shadow_YasDL' ,'B-Nikoo-Italic_YasDL' ,'B-Nikoo_YasDL' ,'B-Paatch-Bold_YasDL' ,'B-Paatch_YasDL' ,'B-Rose_YasDL' ,'B-Roya-Bold_YasDL' ,'B-Roya_YasDL' ,'B-Sahar_YasDL' ,'B-Sahra_YasDL' ,'B-Sara_YasDL' ,'B-Sepideh-Outline_YasDL' ,'B-Sepideh_YasDL' ,'B-Setareh-Bold_YasDL' ,'B-Setareh_YasDL' ,'B-Shadi_YasDL' ,'B-Shiraz-Italic_YasDL' ,'B-Shiraz_YasDL' ,'B-Siavash_YasDL' ,'B-Sina-Bold_YasDL' ,'B-Sooreh-Bold_YasDL' ,'B-Sooreh_YasDL' ,'B-Sorkhpust_YasDL' ,'B-Tabssom_YasDL' ,'B-Tanab_YasDL' ,'B-Tawfig-Outline_YasDL' ,'B-Tehran-Italic_YasDL' ,'B-Tehran_YasDL' ,'B-Tir_YasDL' ,'B-Titr-Bold_YasDL' ,'B-Traffic-Bold_YasDL' ,'B-Traffic_YasDL' ,'B-Vahid-Bold_YasDL' ,'B-Vosta-Italic_YasDL' ,'B-Vosta_YasDL' ,'B-Yagut-Bold_YasDL' ,'B-Yagut_YasDL' ,'B-Yas-Bold_YasDL' ,'B-Yas_YasDL' ,'B-Yekan_YasDL' ,'B-Zaman_YasDL' ,'B-Zar-Bold_YasDL' ,'B-Zar_YasDL' ,'B-Ziba_YasDL' ,'IranianSans' ,'titr' ,'Yekan'
                  
                ],
                supportAllValues: true
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-size-feature
            fontSize: {
                options: [10, 12, 14, 'default', 18, 20, 22],
                supportAllValues: true
            },
            // Be careful with the setting below. It instructs CKEditor to accept ALL HTML markup.
            // https://ckeditor.com/docs/ckeditor5/latest/features/general-html-support.html#enabling-all-html-features
            htmlSupport: {
                allow: [
                    {
                        name: /.*/,
                        attributes: true,
                        classes: true,
                        styles: true
                    }
                ]
            },
            // Be careful with enabling previews
            // https://ckeditor.com/docs/ckeditor5/latest/features/html-embed.html#content-previews
            htmlEmbed: {
                showPreviews: true
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/link.html#custom-link-attributes-decorators
            link: {
                decorators: {
                    addTargetToExternalLinks: true,
                    defaultProtocol: 'https://',
                    toggleDownloadable: {
                        mode: 'manual',
                        label: 'Downloadable',
                        attributes: {
                            download: 'file'
                        }
                    }
                }
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html#configuration
            mention: {
                feeds: [
                    {
                        marker: '@',
                        feed: [
                            '@apple', '@bears', '@brownie', '@cake', '@cake', '@candy', '@canes', '@chocolate', '@cookie', '@cotton', '@cream',
                            '@cupcake', '@danish', '@donut', '@dragée', '@fruitcake', '@gingerbread', '@gummi', '@ice', '@jelly-o',
                            '@liquorice', '@macaroon', '@marzipan', '@oat', '@pie', '@plum', '@pudding', '@sesame', '@snaps', '@soufflé',
                            '@sugar', '@sweet', '@topping', '@wafer'
                        ],
                        minimumCharacters: 1
                    }
                ]
            },
            // The "super-build" contains more premium features that require additional configuration, disable them below.
            // Do not turn them on unless you read the documentation and know how to configure them and setup the editor.
            removePlugins: [
                // These two are commercial, but you can try them out without registering to a trial.
                // 'ExportPdf',
                // 'ExportWord',
                'CKBox',
                'CKFinder',
                'EasyImage',
                // This sample uses the Base64UploadAdapter to handle image uploads as it requires no configuration.
                // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/base64-upload-adapter.html
                // Storing images as Base64 is usually a very bad idea.
                // Replace it on production website with other solutions:
                // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/image-upload.html
                // 'Base64UploadAdapter',
                'RealTimeCollaborativeComments',
                'RealTimeCollaborativeTrackChanges',
                'RealTimeCollaborativeRevisionHistory',
                'PresenceList',
                'Comments',
                'TrackChanges',
                'TrackChangesData',
                'RevisionHistory',
                'Pagination',
                'WProofreader',
                // Careful, with the Mathtype plugin CKEditor will not load when loading this sample
                // from a local file system (file://) - load this site via HTTP server if you enable MathType.
                'MathType',
                // The following features are part of the Productivity Pack and require additional license.
                'SlashCommand',
                'Template',
                'DocumentOutline',
                'FormatPainter',
                'TableOfContents'
            ]
        });
    });
}

// رویداد DOMContentLoaded
document.addEventListener('DOMContentLoaded', () => {
    // فراخوانی تابع برای اعمال تغییرات
    applyChanges();
});


      