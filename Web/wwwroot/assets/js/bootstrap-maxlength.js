// npm package: bootstrap-maxlength
// github link: https://github.com/mimo84/bootstrap-maxlength

'use strict';

(function () {

  $('#defaultconfig').maxlength({
    warningClass: "badge mt-1 bg-success",
    limitReachedClass: "badge mt-1 bg-danger"
  });

  $('#defaultconfig-2').maxlength({
    alwaysShow: true,
    threshold: 20,
    warningClass: "badge mt-1 bg-success",
    limitReachedClass: "badge mt-1 bg-danger"
  });

  $('#defaultconfig-3').maxlength({
    alwaysShow: true,
    threshold: 10,
    warningClass: "badge mt-1 bg-success",
    limitReachedClass: "badge mt-1 bg-danger",
    separator: ' از ',
    preText: 'شما ',
    postText: ' کاراکتر را استفاده کرده اید',
    validate: true
  });

  $('#maxlength-textarea').maxlength({
    alwaysShow: true,
    warningClass: "badge mt-1 bg-success",
    limitReachedClass: "badge mt-1 bg-danger"
  });

})();