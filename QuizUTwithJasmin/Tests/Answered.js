/// <reference path="..\..\Quiz\Scripts/angular.js" />
/// <reference path="..\..\Quiz\Scripts/angular-mocks.js" />
/// <reference path="..\..\Quiz\Scripts\app/quiz-controller.js" />

describe('When using quiz-controller ', function () {
    //initialize Angular
    beforeEach(module('QuizApp'));
    //parse out the scope for use in our unit tests.
    var scope;
    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        var ctrl = $controller('QuizCtrl', { $scope: scope });
    }));

    it('initial value of answered is false', function () {
        expect(scope.answered).toBe(false);
    });
});