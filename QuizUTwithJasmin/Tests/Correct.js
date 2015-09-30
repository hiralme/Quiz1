/// <reference path="..\..\Quiz\Scripts/angular.js" />
/// <reference path="..\..\Quiz\Scripts/angular-mocks.js" />
/// <reference path="..\..\Quiz\Scripts\app/quiz-controller.js" />

it('Object Service', inject(function ($http) {

    var $scope = {};

    $http.get('/api/tech')
      .success(function (data, status, headers, config) {
          $scope.working = true;
          $scope.title = data.title;
      })
      .error(function (data, status, headers, config) {
          $scope.working = false;
      });
    /* End */

    $httpBackend
      .when('GET', '/api/tech')
      .respond(200, { api: 'bar' });

    expect($httpBackend.flush).not.toThrow();

}));