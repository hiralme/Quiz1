/// <reference path="..\..\Quiz\Scripts/angular.js" />
/// <reference path="..\..\Quiz\Scripts/angular-mocks.js" />
/// <reference path="..\..\Quiz\Scripts\app/quiz-controller.js" />

it('should post data (object)', inject(function ($http) {

    var $scope = {};

    /* Code Under Test */
    $http.post('/api/tech', {
        username: 'hardcoded_user',
        password: 'hardcoded_password'
    })
      .success(function (data, status, headers, config) {
          $scope.user = data;
      });
    /* End Code */


    $httpBackend
      .when('POST', '/api/tech', {
          username: 'hardcoded_user',
          password: 'hardcoded_password'
      })
      .respond({
          username: 'hardcoded_user'
      });


    $httpBackend.flush();

    expect($scope.user).toEqual({ username: 'hardcoded_user' });

}));