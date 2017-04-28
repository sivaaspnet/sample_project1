<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="DashboardV2.aspx.cs" Inherits="DashboardV2" Title="Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
  <script src="js/jquery/jquery.mCustomScrollbar.js"></script>
  <script>
		(function($){
			$(window).on("load",function(){
			    $('#course-cont').mCustomScrollbar({
				   theme: 'inset-dark', 
				   autoHideScrollbar: true, 
				   axis:'x',
				   advanced:{autoExpandHorizontalScroll:true}
				});
				
			});
		})(jQuery);
  </script>
<script src="js/jquery/Chart.bundle.min.js"></script>

<script>
    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [85, 15],
                backgroundColor: [
					"#ffffff",
					"#d6902d"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#d6902d"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 80,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config2 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [60, 40],
                backgroundColor: [
					"#ffffff",
					"#53a553"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#53a553"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 80,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config3 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [50, 50],
                backgroundColor: [
					"#ffffff",
					"#177dcc"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#177dcc"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 80,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config4 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [90, 10],
                backgroundColor: [
					"#ffffff",
					"#c34b47"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#c34b47"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 80,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config5 = {
            type: 'line',
            data: {
                labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                datasets: [{
                    data: [ 23, 65, 46, 32, 45, 23, 20, 65, 46, 32, 45, 23 ],
                    backgroundColor: "rgba(255,255,255,0.5)",
                    borderColor: "rgba(1,109,191,1)",
					borderWidth: 2,
                    fill: true,
					fillColor : "rgba(1,109,191,1)",
                    pointHitRadius: 20,
					pointBorderColor: "rgba(2,82,143,1)",
					pointBackgroundColor: "#fff",
					pointBorderWidth:2,
                }]
            },
            options: {
                responsive: true,
                legend: {
					display: false,
					  labels: {
						display: false
					  }
				  },
                hover: {
                    mode: 'index'
                },
				tooltips : {
					enabled: true      
				},
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: false,
                            labelString: 'Month'
                        },
						gridLines : {
							display : false
						},
						ticks: {
						  fontColor: "#fff", // this here
						}
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: false,
                            labelString: 'Value'
                        },
						gridLines : {
							color: "rgba(255,255,255,0.1)"
						},
						ticks: {
						  fontColor: "#fff", // this here
						},
						position: "right"
                    }],
					scaleShowVerticalLines : false,
                },
                title: {
                    display: false,
                    text: 'Chart.js Line Chart - Different point sizes'
                }
            }
        };
	
	var config6 = {
        type: 'doughnut',
        data: {
		    labels: ["Website", "Tv", "Google", "Just Dial", "Sulekha", "Wow", "Newspaper"],
            datasets: [{
                data: [45, 5, 15, 5, 5, 10, 10],
                backgroundColor: [ "#4b89dc", "#36bc9b", "#8cc051", "#eea032", "#e9573e", "#db4453", "#955d94"],
				hoverBackgroundColor: [ "#5d9cec", "#48cfae", "#a0d468", "#ffa72a", "#fb6e52", "#ed5564", "#a66ea3"],
				borderWidth: [ 0, 0, 0, 0, 0, 0, 0 ],
                label: 'Dataset 1'
            }],
        },
        options: {
		    cutoutPercentage: 50,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
			tooltips : {
				enabled: true      
			},
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var barChartData = {
            labels: ["3d Design", "3ds Max", "Advance Digital Sculpting In Z-Brush", "Advance Modelling", "Advanced Flash Scripting", "After Effects", "Basic 3d Design (Maya)", "Combustion", "Digital Design", "Digital Video Production", "Dreamweaver", "E Learning", "Flash Designing", "Flash Programing", "Graphic And Web Design", "Graphic Design", "Graphics And Animation", "Illustrator", "Indesign", "Interior Design", "Jewellery Design", "Matte Painting", "Maya-Animation-Module", "Mobile Gaming", "Photoshop", "Post Production", "Premiere", "Visual Design", "Visual Effects", "Web Design", "Web Photoshop", "2d Animation", "Advertising Design", "Digital Visual Media-Anim & Vfx", "E Learning And Mobile Gaming", "Fashion Designing", "Multimedia Technologies", "Graphics And Animation", "It And Mobile Gaming"],
            datasets: [{
                label: 'Dataset 1',
                backgroundColor: [
				'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)'
			],
                borderColor: [
				'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)'
			],
                borderWidth: 0,
                data: [7, 12, 4, 3, 14, 7, 6, 10, 11, 3, 5, 7, 3, 5, 7, 12, 4, 3, 14, 7, 6, 10, 11, 3, 5, 7, 3, 5, 7, 12, 4, 3, 14, 7, 6, 10, 11, 3, 5]
            }]

        };

	window.onload = function () {
	    $("#<%=ddlyear.ClientID%>").change(function () {	 
	        //var ctx5 = document.getElementById("chart-area5").getContext("2d");
	        //window.myLine = new Chart(ctx5, config5);
	        //myLine.destroy();
	        //var resetCanvas = function () {
	        $('#chart-area5').remove(); // this is my <canvas> element
	        $('#chartdiv').append(' <div style="padding:15px 15px 0px 15px;"><canvas id="chart-area5" width="835" height="220"><canvas></div>');
	            //canvas = document.querySelector('#results-graph');
	            //ctx = canvas.getContext('2d');
	            //ctx.canvas.width = $('#graph').width(); // resize to parent width
	            //ctx.canvas.height = $('#graph').height(); // resize to parent height
	            //var x = canvas.width / 2;
	            //var y = canvas.height / 2;
	            //ctx.font = '10pt Verdana';
	            //ctx.textAlign = 'center';
	            //ctx.fillText('This text is centered on the canvas', x, y);
	        //};
	        //alert("after");
	        linechartfill();
	    });
        Chart.defaults.global.tooltips.enabled = false;      
        var ctx = document.getElementById("chart-area").getContext("2d");
		var ctx2 = document.getElementById("chart-area2").getContext("2d");
		var ctx3 = document.getElementById("chart-area3").getContext("2d");
		var ctx4 = document.getElementById("chart-area4").getContext("2d");
		//var ctx5 = document.getElementById("chart-area5").getContext("2d");
		//var ctx6 = document.getElementById("chart-area6").getContext("2d");		
		var ctx7 = document.getElementById("chart-area7").getContext("2d");            
		//alert("dfgxfdgdgfdfgsdfgsdfggg");
        window.myDoughnut = new Chart(ctx, config);
		window.myDoughnut2 = new Chart(ctx2, config2);
		window.myDoughnut3 = new Chart(ctx3, config3);
		window.myDoughnut4 = new Chart(ctx4, config4);
		//window.myLine = new Chart(ctx5, config5);
        //window.myDoughnut6 = new Chart(ctx6, config6);
       

	
		//alert("b4 chart");
		var dataPoints = [];
            var points = [];
            var labels = [];
            var monthwise = [];
            var monthwiseoverall = [];
            var backcolor = ['rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)', 'rgba(0, 116, 217, 1)', 'rgba(32, 185, 174, 1)', 'rgba(142, 68, 173, 1)', 'rgba(67, 185, 104, 1)', 'rgba(244, 66, 54, 1)', 'rgba(245, 147, 69, 1)'];
            //alert("b4 values");
            var from = document.getElementById("<%=txtfromcalender2.ClientID %>").value;
       // alert("b4 values from" + from);
        var to = document.getElementById("<%=txttocalender2.ClientID %>").value;
       // alert("b4 values to" + to);
        var centreregion = document.getElementById("<%=ddlregion.ClientID %>").value;
        //alert("b4 values region" + centreregion);
        if ($('#<%=ddlcentre.ClientID %>').is(':visible')) {
            var centrecode = document.getElementById("<%=ddlcentre.ClientID %>").value;
           // alert("b4 values centrecode" + centrecode);
        }
        else
            var centrecode = "";
         var year = document.getElementById("<%=ddlyear.ClientID %>").value;
            //alert("b4 data");
            var data = {};
            data.fromdate = from;
            data.todate = to;
            data.centreregion = centreregion;
            data.centrecode = centrecode;
            data.year = year;
         
            $.ajax({
                type: "POST",
                url: "DashboardV2.aspx/getsource",
                data: "{data1:" + JSON.stringify(data) + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                   // alert(response.d);
                },
                error: function (response) {
                    // alert(response.d);
                }
            });
            function OnSuccess(response) {
               // alert("success");
                var xmlDoc = $.parseXML(response.d);
                //alert("response" + response);
                //alert("response.d" + response.d);
                var xml = $(xmlDoc);
                //alert("xml" + xml);
                var customers = xml.find("Table").text;
                //alert("customers" + customers);
                $(xml).find("Table").each(function () {
                    var $dataPoint = $(this);
                    var x = $dataPoint.find("source").text();
                    var y = $dataPoint.find("count").text();
                    dataPoints.push({ label: x, y: parseFloat(y) });
                    labels.push(x);
                    points.push(y);

                });

                var ctx = document.getElementById('chart-area6').getContext('2d');
                ctx.canvas.height = '100';
                ctx.canvas.width = '100';
                var myChart = new Chart(ctx, {
                    type: 'doughnut',
                    options: {
                        responsive: true,
                        legend: {
                            position: 'bottom',
                            display: false
                        },                        
                        tooltips: {
                            enabled: true
                        },
                        title: {
                            display: false
                        }
                    },
                    data: {
                        labels: labels,
                        datasets: [{
                            //label: 'apples',
                            data: points,
                            backgroundColor: backcolor
                        }]
                    }
                });
               // var legend = myChart.generateLegend();
                //$("#legend").html(legend);
            }
          
            var dataPoints1 = [];
            var points1 = [];
            var labels1 = [];
            $.ajax({
                type: "POST",
                url: "DashboardV2.aspx/getcourse",
                data: "{data2:" + JSON.stringify(data) + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess1,               
                failure: function (response) {
                   // alert(response.d);
                },
                error: function (response) {
                   // alert(response.d);
                }
            });
            function OnSuccess1(response) {
               // alert("success");
                var xmlDoc = $.parseXML(response.d);
               //alert("response" + response);
               // alert("response.d" + response.d);
                var xml = $(xmlDoc);
                //alert("xml" + xml);
                var customers = xml.find("Table").text;
                //alert("customers" + customers);
                $(xml).find("Table").each(function () {
                    var $dataPoint = $(this);
                    var x = $dataPoint.find("program").text();
                    var y = $dataPoint.find("count").text();
                    dataPoints1.push({ label: x, y: parseFloat(y) });
                    labels1.push(x);
                    points1.push(y);

                });

                var ctx = document.getElementById('chart-area7').getContext('2d');
                //ctx.canvas.height = '100';
                //ctx.canvas.width = '100';
                var myChart = new Chart(ctx, {
                    type: 'bar',
                    options: {
                        responsive: true,
                        legend: { display: false },
                        title: {
                            display: false,
                            text: 'Chart.js Bar Chart'
                        },
                        scales: {
                            xAxes: [{
                                barPercentage: 0.4,
                                gridLines: { display: false },
                                ticks: { fontSize: 11, maxRotation: 90 }
                            }],
                            yAxes: [{ display: false }],
                        },

                        scaleShowVerticalLines: false,

                        events: false,
                        tooltips: { enabled: false },
                        hover: { animationDuration: 0 },
                        animation: {
                            duration: 1,
                            onComplete: function () {
                                var chartInstance = this.chart,
                                    ctx = chartInstance.ctx;
                                ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                                ctx.textAlign = 'center';
                                ctx.textBaseline = 'bottom';

                                this.data.datasets.forEach(function (dataset) {
                                    for (var i = 0; i < dataset.data.length; i++) {
                                        var model = dataset._meta[Object.keys(dataset._meta)[0]].data[i]._model,
                                            scale_max = dataset._meta[Object.keys(dataset._meta)[0]].data[i]._yScale.maxHeight;
                                        ctx.fillStyle = '#444';
                                        var y_pos = model.y - 5;
                                        if ((scale_max - model.y) / scale_max >= 0.93)
                                            y_pos = model.y + 20;
                                        ctx.fillText(dataset.data[i], model.x, y_pos);
                                    }
                                });
                            }
                        }

                    },
                    data: {
                        labels: labels1,
                        datasets: [{
                            //label: 'apples',
                            data: points1,
                            backgroundColor: backcolor
                        }]
                    }
                });
                // var legend = myChart.generateLegend();
                //$("#legend").html(legend);
            }
            linechartfill();
         
           
		smHits();
	};
    function linechartfill() {
        var dataPoints2 = [];
        var points2 = [];
        var labels2 = [];
         var from = document.getElementById("<%=txtfromcalender2.ClientID %>").value;
        var to = document.getElementById("<%=txttocalender2.ClientID %>").value;
        var centreregion = document.getElementById("<%=ddlregion.ClientID %>").value;
        if ($('#<%=ddlcentre.ClientID %>').is(':visible')) {
            var centrecode = document.getElementById("<%=ddlcentre.ClientID %>").value;
         }
        else
            var centrecode = "";
         var year = document.getElementById("<%=ddlyear.ClientID %>").value;            
            var data = {};
            data.fromdate = from;
            data.todate = to;
            data.centreregion = centreregion;
            data.centrecode = centrecode;
            data.year = year;
        $.ajax({
            type: "POST",
            url: "DashboardV2.aspx/getenroll",
            data: "{data3:" + JSON.stringify(data) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess2,
            failure: function (response) {
                //alert(response.d);
            },
            error: function (response) {
                //alert(response.d);
            }
        });
        function OnSuccess2(response) {
            // alert("success");
            var xmlDoc = $.parseXML(response.d);
            //alert("response" + response);
            // alert("response.d" + response.d);
            var xml = $(xmlDoc);
            //alert("xml" + xml);
            var customers = xml.find("Table").text;
            //alert("customers" + customers);
            $(xml).find("Table").each(function () {
                var $dataPoint = $(this);
                var x = $dataPoint.find("mname").text();
                var y = $dataPoint.find("count").text();
                dataPoints2.push({ label: x, y: parseFloat(y) });
                labels2.push(x);
                points2.push(y);

            });

            var ctx = document.getElementById('chart-area5').getContext('2d');
            
            //ctx.canvas.height = '100';
            //ctx.canvas.width = '100';
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    // labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                    labels: labels2,
                    datasets: [{
                        // data: [ 23, 65, 46, 32, 45, 23, 20, 65, 46, 32, 45, 23 ],
                        data: points2,
                        backgroundColor: "rgba(255,255,255,0.5)",
                        borderColor: "rgba(1,109,191,1)",
                        borderWidth: 2,
                        fill: true,
                        fillColor: "rgba(1,109,191,1)",
                        pointHitRadius: 20,
                        pointBorderColor: "rgba(2,82,143,1)",
                        pointBackgroundColor: "#fff",
                        pointBorderWidth: 2,
                    }]
                },
                options: {
                    responsive: true,
                    legend: {
                        display: false,
                        labels: {
                            display: false
                        }
                    },
                    hover: {
                        mode: 'index'
                    },
                    tooltips: {
                        enabled: true
                    },
                    scales: {
                        xAxes: [{
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Month'
                            },
                            gridLines: {
                                display: false
                            },
                            ticks: {
                                fontColor: "#fff", // this here
                            }
                        }],
                        yAxes: [{
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Value'
                            },
                            gridLines: {
                                color: "rgba(255,255,255,0.1)"
                            },
                            ticks: {
                                fontColor: "#fff", // this here
                            },
                            position: "right"
                        }],
                        scaleShowVerticalLines: false,
                    },
                    title: {
                        display: false,
                        text: 'Chart.js Line Chart - Different point sizes'
                    }
                }

            });
          
        }
    }
</script>
    
  <script type="text/javascript">
function seleChange(obj) {
    
	var selectopt = document.getElementById("ddlcentre");
    var numberOfOptions = selectopt.options.length
    for (i = 0; i < numberOfOptions; i++) {
        selectopt.remove(0)
    }

    var selectBox = obj;
    var selected = selectBox.options[selectBox.selectedIndex].value;
    var textarea = document.getElementById("centre-cont");
	var ddlcampus = document.getElementById("ddlcentre");
	var optn = document.createElement("OPTION");
    optn.text = "Select";
    optn.value = "Select";
    ddlcampus.options.add(optn, 0);

    if(selected === 'Andrapradesh'){
        textarea.style.display = "block";
		var optn = document.createElement("OPTION");
		optn.text = "Ameerpet";
		optn.value = "Ameerpet";
		ddlcampus.options.add(optn, 1);
		var optn = document.createElement("OPTION");
		optn.text = "Himayath Nagar";
		optn.value = "Himayath Nagar";
		ddlcampus.options.add(optn, 2);
    } else if (selected === "karnataka") {
	    textarea.style.display = "block";
		var optn = document.createElement("OPTION");
		optn.text = "Ganga Nagar";
		optn.value = "Ganga Nagar";
		ddlcampus.options.add(optn, 1);
		var optn = document.createElement("OPTION");
		optn.text = "Indira Nagar";
		optn.value = "Indira Nagar";
		ddlcampus.options.add(optn, 2);
		var optn = document.createElement("OPTION");
		optn.text = "Jayanagar";
		optn.value = "Jayanagar";
		ddlcampus.options.add(optn, 3);
		var optn = document.createElement("OPTION");
		optn.text = "Yelahanka";
		optn.value = "Yelahanka";
		ddlcampus.options.add(optn, 4);
	} else if (selected === "kerala") {
	    textarea.style.display = "block";
		var optn = document.createElement("OPTION");
		optn.text = "Calicut";
		optn.value = "Calicut";
		ddlcampus.options.add(optn, 1);
		var optn = document.createElement("OPTION");
		optn.text = "Kannur";
		optn.value = "Kannur";
		ddlcampus.options.add(optn, 2);
		var optn = document.createElement("OPTION");
		optn.text = "Kollam";
		optn.value = "Kollam";
		ddlcampus.options.add(optn, 3);
		var optn = document.createElement("OPTION");
		optn.text = "Kottayam";
		optn.value = "Kottayam";
		ddlcampus.options.add(optn, 4);
		var optn = document.createElement("OPTION");
		optn.text = "Palarivattom";
		optn.value = "Palarivattom";
		ddlcampus.options.add(optn, 5);
		var optn = document.createElement("OPTION");
		optn.text = "Pathanamthitta";
		optn.value = "Pathanamthitta";
		ddlcampus.options.add(optn, 6);
		var optn = document.createElement("OPTION");
		optn.text = "Palakkad";
		optn.value = "Palakkad";
		ddlcampus.options.add(optn, 7);
		var optn = document.createElement("OPTION");
		optn.text = "Thiruvananthapuram";
		optn.value = "Thiruvananthapuram";
		ddlcampus.options.add(optn, 8);
		var optn = document.createElement("OPTION");
		optn.text = "Thrissur";
		optn.value = "Thrissur";
		ddlcampus.options.add(optn, 9);
		var optn = document.createElement("OPTION");
		optn.text = "Thodupuzha";
		optn.value = "Thodupuzha";
		ddlcampus.options.add(optn, 10);
		var optn = document.createElement("OPTION");
		optn.text = "Valanjambalam";
		optn.value = "Valanjambalam";
		ddlcampus.options.add(optn, 11);
	} else{
        textarea.style.display = "none";
    }
}
</script>
  <script> 
function smHits () {
	var nodeList = document.getElementsByClassName("eq-hit");
	var elems = [].slice.call(nodeList);
	
	var tallest = Math.max.apply(Math, elems.map(function(elem, index) {
	elem.style.height = ''; // clean first
	return elem.offsetHeight;
	}));
	
	elems.forEach(function(elem, index, arr){ 
	elem.style.height = tallest + 'px';
	});	  
}

var resized = true;
var timeout = null;

var refresh = function(){
	if(resized) {
		requestAnimationFrame(smHits);
	}
	clearTimeout(timeout);
	timeout = setTimeout( refresh, 100);
	resized = false;
};

window.addEventListener('resize', function() { resized = true; });

refresh();

window.onscroll = smHits;

$(document).ready(function(){
    smHits();
});
</script>
  <script src="js/jquery/raphael-2.1.4.min.js"></script>
  <script src="js/jquery/justgage.js"></script>
  <script>
      document.addEventListener("DOMContentLoaded", function (event) {         
          var telepercentage = document.getElementById("<%=hdntele.ClientID%>").value;
          var walkinepercentage = document.getElementById("<%=hdnwalkin.ClientID%>").value;
          
        var g1, g2;
		var g1 = new JustGage({
            id: "g1",
            value: parseInt(telepercentage,10),
            min: 0,
            max: 100,
			symbol: "%",
            title: "Tele Enquiry",
            relativeGaugeSize: true,
            donut: false,
			titlePosition:'below',
			gaugeWidthScale: 0.5,
			customSectors : [{"lo":0,"hi":100,"color":"#09b03d"}],
                   //{"lo":11,"hi":22,"color":"#f9c802"},
                   //{"lo":23,"hi":34,"color":"#ff0000"}],
            levelColorsGradient: false
        });
        var g2 = new JustGage({
            id: "g2",
            value: parseInt(walkinepercentage, 10),
            min: 0,
            max: 100,
			symbol: "%",
            title: "Walkin Enquiry",
            relativeGaugeSize: true,
            donut: false,
			titlePosition:'below',
			gaugeWidthScale: 0.5,
			customSectors : [{"lo":0,"hi":100,"color":"#1c80d7"}],
            levelColorsGradient: false
        });        
    });
</script>
    

  <style type="text/css">
.overlay{
	position: fixed;
	z-index: 98;
	top: 0px;
	left: 0px;
	right: 0px;
	bottom: 0px;
	background-color: #fff;
	filter: alpha(opacity=80);
	opacity: 0.8;
}
.overlayContent{
	z-index: 99;
	margin: 250px auto;
	width: 80px;
	height:80px;
}
.overlayContent h2{
	font-size: 18px;
	font-weight: bold;
	color: #000;
}

.style1{
	width: 83px;
}
.tbl{
	border-collapse: collapse;
	width:100%;
}

.tbl td {
	border: 1px solid black;
	text-align: center;
}
.tbl th {
	border: 1px solid black;
}
.chart-container {
	height:210px;
	padding:15px 15px 0px 15px;
}
canvas#chart-area, canvas#chart-area2, canvas#chart-area3, canvas#chart-area4, canvas#chart-area5, canvas#chart-area6{
	width: 100% !important;
	max-width: 1110px;
	height: auto !important;
}
canvas#chart-area7{
	width: 100% !important;
	height: auto !important;
}
.WebRupee {
    font-weight: normal;
}
</style>
  
  <div class="free-forms">
    <div class="title-cont">
      <h3 class="cont-title">Dashboard</h3>
      <div class="breadcrumps">
        <ul>
          <li><a href="DashboardV2.aspx" class="last">Dashboard</a></li>
        </ul>
      </div>
      <div class="clear"></div>
    </div>
    <div class="search-sec-cont">
      <ul>
        <li>
          <div class="wth-1">Region</div>
          <div class="wth-2">
            <asp:DropDownList runat="server" ID="ddlregion" CssClass="sele-txt"  AutoPostBack="true" OnSelectedIndexChanged="ddlregionchanged"></asp:DropDownList>
          </div>
        </li><%--onchange="seleChange(this)"--%>
        <li id="textarea" runat="server" visible="false">
          <div class="wth-1">Centre</div>
          <div class="wth-2">
             <asp:DropDownList runat="server" ID="ddlcentre" CssClass="sele-txt"  autocomplete="off"></asp:DropDownList>
          </div>
        </li>
        <li class="date-sec-cont">
          <div class="wth-1">Date From</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txtfromcalender2" onkeypress="return false" onkeydown="return false" onpaste="return false" runat="server" CssClass="text datepicker1 date-input-txt"></asp:TextBox>
          </div>
          <div class="wth-3">To</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txttocalender2" onkeypress="return false" onkeydown="return false" onpaste="return false" runat="server" CssClass="text datepicker1 date-input-txt"></asp:TextBox>
          </div>
        </li>
        <li>
          <asp:Button ID="btnsort1" OnClick="btnsort1_Click" runat="server" Text="Apply" CssClass="btnStyle1" OnClientClick="javascript:return sortval2();"></asp:Button>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="statistics">
      <ul>
        <li>
          <div class="statistics-item-1">
            <div class="st-lt">
              <canvas id="chart-area" height="1" width="1"></canvas>
              <div class="img-cont"><img src="images/diploma-icon.png" /></div>
            </div>
            <div class="st-rt"><div runat="server" id="diplomacount">0</div><span>Diploma</span> </div>
            <div class="clear"></div>
          </div>
        </li>
        <li>
          <div class="statistics-item-2">
            <div class="st-lt">
              <canvas id="chart-area2" height="1" width="1"></canvas>
              <div class="img-cont"><img src="images/diploma-icon.png" /></div>
            </div>
            <div class="st-rt"><div runat="server" id="hdiplomacount">0</div><span>Higher Diploma</span> </div>
            <div class="clear"></div>
          </div>
        </li>
        <li>
          <div class="statistics-item-3">
            <div class="st-lt">
              <canvas id="chart-area3" height="1" width="1"></canvas>
              <div class="img-cont"><img src="images/diploma-icon.png" /></div>
            </div>
            <div class="st-rt"><div runat="server" id="certificatecount">0</div><span>Certificate</span> </div>
            <div class="clear"></div>
          </div>
        </li>
        <li class="last">
          <div class="statistics-item-4">
            <div class="st-lt">
              <canvas id="chart-area4" height="1" width="1"></canvas>
              <div class="img-cont"><img src="images/diploma-icon.png" /></div>
            </div>
            <div class="st-rt"><div runat="server" id="hcertificatecount">0</div><span>Higher Certificate</span></div>
            <div class="clear"></div>
          </div>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="enrollment-section lt-cont eq-ht">      
      <div class="enroll-rt">
        <div style="padding:15px 15px 10px 0px;" align="right" id="chartdiv">
            <asp:DropDownList runat="server" ID="ddlyear" class="sele-txt" style="border:1px solid #177dcc"></asp:DropDownList>
         
        </div>
        <div style="padding:15px 15px 0px 15px;">
          <canvas id="chart-area5"width="835" height="220"></canvas>
        </div>
        <div class="clear"></div>
      </div>
      <div class="enroll-lt">
        <div class="padd-cont">
          <div class="enroll-details">
          <div class="enroll-perznt">89<sup>%</sup></div>
          <div class="enroll-perznt-tle">Overall - Enrollment Percentage</div>
          </div>
          <table cellpadding="0" cellspacing="0" border="0" class="enroll-data">
            <tr>
              <td class="enroll-value">1234</td>
              <td class="enroll-title">Enroll</td>
            </tr>
            <tr>
              <td class="enroll-value">234</td>
              <td class="enroll-title">Lorem</td>
            </tr>
            <tr>
              <td class="enroll-value">123</td>
              <td class="enroll-title">Ipsum</td>
            </tr>
          </table>
          <div class="clear"></div>
        </div>
      </div>
      <div class="clear"></div>
    </div>
    <div class="rt-cont white-cont eq-ht">
      <h3 class="cont-title2">Payment Mode</h3>
        <ul class="pay-list">
          <li class="pay-li-1">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
              <tr>
                <td class="pay-lt"><div align="center"><img src="images/pay-icon-1.png" /></div></td>
                <td class="pay-rt"><div class="pay-cout"><%--27--%></div>
                  <div class="pay-value">
                    <h3 class="pay-title">Cash</h3>
                    <span style="font-family:rupee;font-size:20px">R</span><asp:Label runat="server" ID="lblcash"></asp:Label></div>
                  <div class="clear"></div>
                  <div class="pay-percent">
                    <div class="pay-fill" id="divcash" runat="server" style="width:0%;"></div>
                  </div></td>
              </tr>
            </table>
          </li>
          <li class="pay-li-2">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
              <tr>
                <td class="pay-lt"><div align="center"><img src="images/pay-icon-2.png" /></div></td>
                <td class="pay-rt"><div class="pay-cout"><%--18--%></div>
                  <div class="pay-value">
                    <h3 class="pay-title">Cheque</h3>
                    <span style="font-family:rupee;font-size:20px">R</span><asp:Label runat="server" ID="lblcheque"></asp:Label></div>
                  <div class="clear"></div>
                  <div class="pay-percent">
                    <div class="pay-fill" id="divcheque" runat="server" style="width:0%;"></div>
                  </div></td>
              </tr>
            </table>
          </li>
          <li class="pay-li-3">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
              <tr>
                <td class="pay-lt"><div align="center"><img src="images/pay-icon-3.png" /></div></td>
                <td class="pay-rt"><div class="pay-cout"><%--21--%></div>
                  <div class="pay-value">
                    <h3 class="pay-title">Online Transations</h3>
                    <span style="font-family:rupee;font-size:20px">R</span><asp:Label runat="server" ID="lblonline"></asp:Label></div>
                  <div class="clear"></div>
                  <div class="pay-percent">
                    <div class="pay-fill" id="divonline" runat="server" style="width:0%;"></div>
                  </div></td>
              </tr>
            </table>
          </li>
          <li class="pay-li-4">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
              <tr>
                <td class="pay-lt"><div align="center"><img src="images/pay-icon-4.png" /></div></td>
                <td class="pay-rt"><div class="pay-cout"><%--66--%></div>
                  <div class="pay-value">
                    <h3 class="pay-title">Total</h3>
                    <span style="font-family:rupee;font-size:20px">R</span><asp:Label runat="server" ID="lbltotal"></asp:Label></div>
                  <div class="clear"></div>
                  <div class="pay-percent">
                    <div class="pay-fill" id="divtotal" runat="server" style="width:0%;" ></div>
                  </div></td>
              </tr>
            </table>
          </li>
        </ul>
    </div>
    <div class="clear"></div>
    <!--<div class="lt-cont">
      <div class="white-cont">
        <h3 class="cont-title2">Collection Summary</h3>
        <div class="padd-cont">
        <div class="dataGrid">
          <asp:GridView ID="Gridviewdashboard" runat="server" CssClass="common2" AllowPaging="True" AutoGenerateColumns="False"  EmptyDataText="No records Found" OnRowCommand="Gridview_dashboard_RowCommand" PageSize="15" Width="100%">
            <Columns>
            <asp:TemplateField HeaderText="Centre">
              <ItemTemplate>
                <asp:Label runat="server" ID="lblcentrename" Text='<%#Eval("centreName")%>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Billed Value">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnkbilled" CommandName="billedvalue" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("BilledValue")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diploma">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnkdiploma" CommandName="diploma" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("DiplomaCount")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Certificate">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnkcertificate" CommandName="certificate" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("CertificateCount")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Collection">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnktotalColl" CommandName="totalcollection" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("TotalCollection")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fees Receivable">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnkfeesrec" CommandName="feesreceivable" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("FeesReceivable")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dropout Amount">
              <ItemTemplate>
                <asp:LinkButton  Font-Underline="false" ID="lnkdropout" CommandName="dropoutamount" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("DropoutAmount")%></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
            <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
          </asp:GridView>
          <td colspan="3" style="border: 1px solid #ccc"><h4 style="text-align: center"> </h4>
            <div id="wrap" runat="server"  visible="false">
              <table  class="tbl">
                <tbody>
                  <tr >
                    <th> S.No </th>
                    <th> Centre Name </th>
                    <th> Billed Value </th>
                    <th> Diploma </th>
                    <th> Certificate </th>
                    <th> Total Collection </th>
                    <th> Fees Receivable </th>
                    <th> Dropout Amount </th>
                  </tr>
                  <%=getdata()%>
                </tbody>
                
              </table>
            </div></td>
        </div>
        <div style="text-align: center; padding:0px 0px 13px 0px;">
          <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="download-btn">Download Excel</asp:LinkButton>
        </div>
        </div>
      </div>
      <div class="white-cont no-mrg">
        <h3 class="cont-title2">Sourcewise Count</h3>
        <div class="chart-container">
          <canvas id="source-grp"></canvas>
        </div>
      </div>
    </div>-->
    <div class="rt-cont eq-hit" style="float:left; margin-right:2.45%; margin-bottom:20px;">
      <div class="white-cont enq-cont" style="height:100%; margin:0px;">
        <div class="enq-title-cont">
          <h4 class="enq-title">Enquiry</h4>
          <div class="enq-title2">Enrolled</div>
          <div class="enq-title-vle">177</div>
          <div class="clear"></div>
        </div>
        <div class="padd-cont">
          <ul>
            <li class="total"><div class="enq-desc">Total Enquiry</div>
              <h3 class="enq-vle"><%--<span style="font-family:rupee;font-size:20px">R</span>--%><asp:Label runat="server" ID="lbltotenq" Text="0"></asp:Label></h3></li>
            <li>
              <div class="enq-desc">Tele Enquiry</div>
              <h3 class="enq-vle"><%--<span style="font-family:rupee;font-size:20px">R</span>--%><asp:Label runat="server" ID="lblteleenq" Text="0"></asp:Label></h3>
              <div id="g1" class="gauge"></div>
            </li>
            <li class="enq2">
              <div class="enq-desc">Walkin Enquiry</div>
              <h3 class="enq-vle"><%--<span style="font-family:rupee;font-size:20px">R</span>--%><asp:Label runat="server" ID="lblwalkinenq" Text="0"></asp:Label></h3>
              <div id="g2" class="gauge"></div>
            </li>
          </ul>
          <div class="clear"></div>
        </div>
      </div>
    </div>
    <div class="white-cont rt-cont eq-hit" style="float:left; margin-right:2.45%; margin-bottom:20px;">
      <h3 class="cont-title2">Profiles</h3>
      <div class="padd-cont">
        <ul class="profile-lists mCustomScrollbar">
           <asp:Literal runat="server" ID="holderprofile"></asp:Literal>
      <%--    <li>
            <div class="pro-list1">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>
          <li>
            <div class="pro-list2">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>
          <li>
            <div class="pro-list3">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>
          <li>
            <div class="pro-list4">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>
          <li>
            <div class="pro-list5">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>
          <li>
            <div class="pro-list6">
              <div class="pro-vlu"><span style="font-family:rupee;font-size:20px">R</span>34, 567</div>
              <div class="pro-dts">
                <span class="pro-lt">Fresh</span>
                <span class="pro-rt">33%</span>
                <div class="clear"></div>
              </div>
              <div class="prt"><span style="width:40%"></span></div>
            </div>
          </li>--%>
        </ul>
      </div>
    </div>
    <div class="rt-cont eq-hit" style="margin-bottom:20px;">
      <div class="white-cont" style="height:100%; margin:0px;">
        <h3 class="cont-title2">Source</h3>
        <div class="padd-cont">
          <canvas id="chart-area6" height="1" width="1"></canvas>
        </div>
      </div>
    </div>
    <div class="clear"></div>
    <div class="white-cont">
      <h3 class="cont-title2">Collection Summary</h3>
      <div class="padd-cont">
          <div style="padding:0px 10px 10px 10px">
      <asp:GridView ID="Gridview_collection" runat="server" CssClass="tbl-cont3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_collection_PageIndexChanging" EmptyDataText="No records Found" PageSize="5" Width="100%">
        <Columns>
            <asp:BoundField DataField="centreName"  HeaderText="Centre"/>
            <asp:BoundField DataField="FreshCount"  HeaderText="Fresh"  ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="RegularCount"  HeaderText="Regular" ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="OthersCount"  HeaderText="Others" ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="TotalCollection"  HeaderText="Total Collection" ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="FeesReceivable"  HeaderText="Fees Receivable" ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="DropoutAmount"  HeaderText="Dropout Amount" ItemStyle-CssClass="txt-al-ctr"/>
            <asp:BoundField DataField="BilledValue"  HeaderText="Billed Value" ItemStyle-CssClass="txt-al-ctr"/>     
        </Columns>
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView></div>
        <%--<table class="tbl-cont3" cellpadding="0" cellspacing="0" border="0" width="100%">
          <tr>
            <th width="18%">Centre</th>
            <th width="7%">Registered</th>
            <th width="7%">Fresh</th>
            <th width="7%">Regular</th>
            <th width="7%">Others</th>
            <th width="13%">Total Collection</th>
            <th width="13%">Fees Receivable</th>
            <th width="15%">Dropout Amount</th>
            <th width="13%">Billed Value</th>
          </tr>
          <tr>
            <td>Ameerpet</td>
            <td class="txt-al-ctr">87</td>
            <td class="txt-al-ctr">15</td>
            <td class="txt-al-ctr">26</td>
            <td class="txt-al-ctr"> - </td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>895000</td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>1126200</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
          </tr>
          <tr>
            <td>Bhubaneshwar</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
          </tr>
          <tr>
            <td>Guwahati</td>
            <td class="txt-al-ctr">100</td>
            <td class="txt-al-ctr">11</td>
            <td class="txt-al-ctr">1</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>383600</td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>664900</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
          </tr>
          <tr>
            <td>Himayatnagar</td>
            <td class="txt-al-ctr">72</td>
            <td class="txt-al-ctr">5</td>
            <td class="txt-al-ctr">4</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>178000</td>
            <td class="txt-al-rt"><span style="font-family:rupee;font-size:20px">R</span>631500</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
          </tr>
          <tr>
            <td>Varanasi </td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-ctr">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
            <td class="txt-al-rt">-</td>
          </tr>
        </table>--%>
      </div>
    </div>
    <div class="clear"></div>
    <div class="white-cont no-mrg">
      <h3 class="cont-title2">Course Summary</h3>
      <div class="padd-cont">
        <div id="course-cont" class="chart-cont" style="overflow:auto;">
          <div style="width:1500px;">
            <canvas id="chart-area7" width="1500" height="350"></canvas>
          </div>
        </div>
      </div>
    </div>
  </div>
  <asp:HiddenField  runat="server" ID="hfcentre" />
    <asp:HiddenField  runat="server" ID="hdntele" Value="0"/>
     <asp:HiddenField  runat="server" ID="hdnwalkin" Value="0"/>
   <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
  <script type="text/javascript" src="scripts/main.js"></script>  
  <script type="text/javascript">
    $(document).ready(function () {
    
	  jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/cal.png', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'mm-dd-yy', yearRange: '1970:2020' });
	  Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
		
	  function EndRequestHandler(sender, args) {
		jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/cal.png', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'mm-dd-yy', yearRange: '1970:2020' });
	  }
    
    });            
    
  </script>
</asp:Content>
