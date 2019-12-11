
    var testCases = $(".testcase");

    $(".testcase").draggable();

var TaskEditor = function(){
    this.TestCases = null;
    this.Requirments = null;
    this.TestContainer = null;
    this.Laba = null;

}

TaskEditor.prototype.init = function (laba) {
    var self = this;
    this.Laba = laba;
    this.TestCases = $(".testcase");
    this.TestCases.draggable({ revert: "invalid", zIndex: 2500 });
    this.Requirments = $(".requirment");
    this.Requirments.droppable({
        classes: {
            "ui-droppable-hover": "ui-state-hover"
        },
        drop: function (event, ui) {
            $(this).parent().append(ui.helper);
            ui.helper.css({ top: 0, left: 0, position: 'relative' });
            $(this).removeClass("on-requirment");
            var reqId = $(this).attr("requirmentid");
            var testId = ui.helper.attr("testid");
            self.Laba.labaCases.forEach(element => {
                if(element.testCaseId == testId)
                {
                    element.requirmentId = parseInt(reqId);
                }
            });
            console.log(self.Laba);
        },
        over: function (event, ui) {
            // over droppable        
            //console.log('over');

            $(this).addClass("on-requirment");

                //.addClass($(this).attr('id'));
        },
        out: function (event, ui) {
            // not over droppable
            //console.log('out');

            // reset
            $(this).removeClass("on-requirment");
        }
    });

    this.TestContainer = $("#testcase-container");
    this.TestContainer.droppable(
        {
            
            classes: {
                "ui-droppable-hover": "ui-state-hover"
            },
            drop: function (event, ui) {
                $(".stack").css('z-index', '2500');
                $(this).append(ui.helper);
                ui.helper.css({ top: 0, left: 0, position: 'relative' });
                $(this).removeClass("testcase-container-on");
                var testId = ui.helper.attr("testid");
                self.Laba.labaCases.forEach(element => {
                    if(element.testCaseId == testId)
                    {
                        element.requirmentId = null;
                    }
                });
                console.log(self.Laba);
            },
            over: function (event, ui) {
                // over droppable        
                //console.log('over');

                $(this).addClass("testcase-container-on");

                //.addClass($(this).attr('id'));
            },
            out: function (event, ui) {
                // not over droppable
                //console.log('out');

                // reset
                $(this).removeClass("testcase-container-on");
            }
        }
    );

    $(".testcasetype-select").change(function () {
        var testId = $(this).parent().parent().attr("testid");
        self.Laba.labaCases.forEach(element => {
            if (element.testCaseId == testId) {
                element.testCaseType = $(this).val();
            }
        });
        console.log($(this).val());
        console.log(testId);
    })

    for (var i = 0; i < $(".testcasetype-select").length; i++) {
        for(var j =0;j < self.Laba.labaCases.length; j++)
        {
            var testId = $($(".testcasetype-select")[i]).parent().parent().attr("testid");
            if(self.Laba.labaCases[j].testCaseId == testId)
            {
                $(".testcasetype-select")[i].value = self.Laba.labaCases[j].testCaseType;
            }
        }
    }
    $("#save-action").on("click", function()
    {
        self.Laba.labaStatus = 0;
        $.ajax({
            url: "/LabasStudent/Edit/" + self.Laba.id,
            type: "post",
            data : {laba : self.Laba}

        })
    });

    
    $("#ready-action").on("click", function()
    {
        self.Laba.labaStatus = 3;
        $.ajax({
            url: "/LabasStudent/Edit/" + self.Laba.id,
            type: "post",
            data : {laba : self.Laba}

        })
    });

}