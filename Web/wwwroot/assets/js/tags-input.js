// npm package: jquery-tags-input
// github link: https://github.com/xoxco/jQuery-Tags-Input

'use strict';

(function () {

  $('#tags').tagsInput({
    'width': '100%',
    'height': '75%',
    'interactive': true,
    'defaultText': 'افزودن',
    'removeWithBackspace': true,
    'minChars': 0,
    'maxChars': 20,
    'placeholderColor': '#666666'
  });

})();