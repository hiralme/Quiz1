angular.module('QuizApp', [])
    .controller('QuizCtrl', function ($scope, $http) {
        $scope.answered = false;
        $scope.title = "loading question...";
        $scope.options = [];
        $scope.correctAnswer = false;
        $scope.working = false;

        $scope.answer = function () {
            return $scope.correctAnswer ? 'correct' : 'incorrect';
        };

        $scope.nextQuestion = function () {
            $scope.working = true;

            $scope.answered = false;
            $scope.title = "loading question...";
            $scope.options = [];
            $scope.scorecard = false;

            $http.get("/api/tech").success(function (data, status, headers, config) {
                $scope.options = data.options;
                $scope.title = data.title;
                $scope.answered = false;
                $scope.working = false;
                if(data.options == null || data.options=="")
                { $scope.scorecard = data.title }
                $scope.scorecard = true;
            }).error(function (data, status, headers, config) {
                $scope.title = "something went wrong";
                $scope.working = false;
            });
        };

        $scope.sendAnswer = function (option) {
            $scope.working = true;
            $scope.answered = true;

            $http.post('/api/tech', { 'questionId': option.questionId, 'optionId': option.id }).success(function (data, status, headers, config) {
                $scope.correctAnswer = (data == true);
                $scope.working = false;
            }).error(function (data, status, headers, config) {
                $scope.title = "something went wrong";
                $scope.working = false;
            });
        };
    });