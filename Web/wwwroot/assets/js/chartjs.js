// npm package: chart.js
// github link: https://github.com/chartjs/Chart.js

'use strict';

(function () {

  // JS global variables from app.js file 
  const colors = window.config.colors;
  const fontFamily = window.config.fontFamily;




  // Bar chart
  const chartjsBar = document.querySelector('#chartjsBar');
  if (chartjsBar) {
    new Chart(chartjsBar, {
      type: 'bar',
      data: {
        labels: ["ایران", "چین", "ترکیه", "آلمان", "استرالیا"],
        datasets: [{
          label: "جمعیت",
          backgroundColor: [colors.primary, colors.danger, colors.warning, colors.success, colors.info],
          data: [2478, 5267, 734, 2084, 1433],
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: false
          },
        },
        scales: {
          x: {
            display: true,
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          }
        }
      }
    });
  }




  // Line Chart
  const chartjsLine = document.querySelector('#chartjsLine');
  if (chartjsLine) {
    new Chart(chartjsLine, {
      type: 'line',
      data: {
        labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
        datasets: [{
          data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
          label: "آفریقا",
          borderColor: colors.info,
          backgroundColor: "transparent",
          fill: true,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }, {
          data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
          label: "آسیا",
          borderColor: colors.danger,
          backgroundColor: "transparent",
          fill: true,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            display: true,
            labels: {
              rtl: true,
              display: true,
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        scales: {
          x: {
            display: true,
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          }
        }
      }
    });
  }




  // Doughnut Chart
  const chartjsDoughnut = document.querySelector('#chartjsDoughnut');
  if (chartjsDoughnut) {
    new Chart(chartjsDoughnut, {
      type: 'doughnut',
      data: {
        labels: ["آفریقا", "آسیا", "اروپا"],
        datasets: [{
          label: "جمعیت (میلیون)",
          backgroundColor: [colors.primary, colors.danger, colors.info],
          borderColor: colors.light,
          data: [2478, 4267, 1334],
        }]
      },
      options: {
        aspectRatio: 2,
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        }
      }
    });
  }




  // Area Chart
  const chartjsArea = document.querySelector('#chartjsArea');
  if (chartjsArea) {
    new Chart(chartjsArea, {
      type: 'line',
      data: {
        labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
        datasets: [{
          data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
          label: "آفریقا",
          borderColor: colors.danger,
          backgroundColor: 'rgba(255,51,102,.3)',
          fill: true,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }, {
          data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
          label: "آسیا",
          borderColor: colors.info,
          backgroundColor: 'rgba(102,209,209,.3)',
          fill: true,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        scales: {
          x: {
            display: true,
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          }
        }
      }
    });
  }




  // Pie Chart
  const chartjsPie = document.querySelector('#chartjsPie');
  if (chartjsPie) {
    new Chart(chartjsPie, {
      type: 'pie',
      data: {
        labels: ["آفریقا", "آسیا", "اروپا"],
        datasets: [{
          label: "جمعیت (میلیون)",
          backgroundColor: [colors.primary, colors.danger, colors.info],
          borderColor: colors.light,
          data: [2478, 4267, 1334]
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        aspectRatio: 2,
      }
    });
  }




  // Bubble Chart
  const chartjsBubble = document.querySelector('#chartjsBubble');
  if (chartjsBubble) {
    new Chart(chartjsBubble, {
      type: 'bubble',
      data: {
        labels: "آفریقا",
        datasets: [{
          label: ["چین"],
          backgroundColor: 'rgba(102,209,209,.3)',
          borderColor: colors.info,
          data: [{
            x: 21269017,
            y: 5.245,
            r: 15
          }]
        }, {
          label: ["دانمارک"],
          backgroundColor: "rgba(255,51,102,.3)",
          borderColor: colors.danger,
          data: [{
            x: 258702,
            y: 7.526,
            r: 10
          }]
        }, {
          label: ["آلمان"],
          backgroundColor: "rgba(101,113,255,.3)",
          borderColor: colors.primary,
          data: [{
            x: 3979083,
            y: 6.994,
            r: 15
          }]
        }, {
          label: ["ژاپن"],
          backgroundColor: "rgba(251,188,6,.3)",
          borderColor: colors.warning,
          data: [{
            x: 4931877,
            y: 5.921,
            r: 15
          }]
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        scales: {
          x: {
            display: true,
            title: {
              display: true,
              text: "جمعیت آماری",
              color: colors.secondary
            },
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            display: true,
            title: {
              display: true,
              text: "شادی",
              color: colors.secondary
            },
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
        }
      }
    });
  }




  // Radar Chart
  const chartjsRadar = document.querySelector('#chartjsRadar');
  if (chartjsRadar) {
    new Chart(chartjsRadar, {
      type: 'radar',
      data: {
        labels: ["آفریقا", "آسیا", "اروپا", "آمریکا لاتین", "آمریکا شمالی"],
        datasets: [{
          label: "1303",
          fill: true,
          backgroundColor: "rgba(255,51,102,.3)",
          borderColor: colors.danger,
          pointBorderColor: colors.danger,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          data: [8.77, 55.61, 21.69, 6.62, 6.82]
        }, {
          label: "1403",
          fill: true,
          backgroundColor: "rgba(102,209,209,.3)",
          borderColor: colors.info,
          pointBorderColor: colors.info,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          data: [25.48, 54.16, 7.61, 8.06, 4.45]
        }]
      },
      options: {
        aspectRatio: 2,
        scales: {
          r: {
            angleLines: {
              display: true,
              color: colors.gridBorder,
            },
            grid: {
              color: colors.gridBorder
            },
            suggestedMin: 0,
            suggestedMax: 60,
            ticks: {
              backdropColor: colors.light,
              color: colors.secondary,
              font: {
                size: 11,
                family: fontFamily
              }
            },
            pointLabels: {
              color: colors.secondary,
              font: {
                color: colors.secondary,
                family: fontFamily,
                size: '13px'
              }
            }
          }
        },
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
      }
    });
  }




  // Polar Area Chart
  const chartjsPolarArea = document.querySelector('#chartjsPolarArea');
  if (chartjsPolarArea) {
    new Chart(chartjsPolarArea, {
      type: 'polarArea',
      data: {
        labels: ["آفریقا", "آسیا", "اروپا", "آمریکا لاتین"],
        datasets: [{
          label: "جمعیت (میلیون)",
          backgroundColor: [colors.primary, colors.danger, colors.success, colors.info],
          borderColor: colors.light,
          data: [3578, 5000, 1034, 2034]
        }]
      },
      options: {
        aspectRatio: 2,
        scales: {
          r: {
            angleLines: {
              display: true,
              color: colors.gridBorder,
            },
            grid: {
              color: colors.gridBorder
            },
            suggestedMin: 1000,
            suggestedMax: 5500,
            ticks: {
              backdropColor: colors.light,
              color: colors.secondary,
              font: {
                size: 11,
                family: fontFamily
              }
            },
            pointLabels: {
              color: colors.secondary,
              font: {
                color: colors.secondary,
                family: fontFamily,
                size: '13px'
              }
            }
          }
        },
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
      }
    });
  }




  // Grouped Bar Chart
  const chartjsGroupedBar = document.querySelector('#chartjsGroupedBar');
  if (chartjsGroupedBar) {
    new Chart(chartjsGroupedBar, {
      type: 'bar',
      data: {
        labels: ["1300", "1350", "1400", "1450"],
        datasets: [{
          label: "آفریقا",
          backgroundColor: colors.danger,
          data: [133, 221, 783, 2478]
        }, {
          label: "اروپا",
          backgroundColor: colors.primary,
          data: [408, 547, 675, 734]
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        scales: {
          x: {
            display: true,
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          }
        }
      }
    });
  }




  // Mixed Line Bar Chart
  const chartjsMixedBar = document.querySelector('#chartjsMixedBar');
  if (chartjsMixedBar) {
    new Chart(chartjsMixedBar, {
      type: 'bar',
      data: {
        labels: ["1300", "1350", "1400", "1450"],
        datasets: [{
          label: "اروپا",
          type: "line",
          borderColor: colors.danger,
          backgroundColor: "transparent",
          data: [408, 547, 675, 734],
          fill: false,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }, {
          label: "آفریقا",
          type: "line",
          borderColor: colors.primary,
          backgroundColor: "transparent",
          data: [133, 221, 783, 2478],
          fill: false,
          pointBackgroundColor: colors.light,
          pointBorderWidth: 2,
          pointHoverBorderWidth: 3,
          tension: .3
        }, {
          label: "اروپا",
          type: "bar",
          backgroundColor: colors.danger,
          data: [408, 547, 675, 734],
        }, {
          label: "آفریقا",
          type: "bar",
          backgroundColor: colors.primary,
          data: [133, 221, 783, 2478]
        }]
      },
      options: {
        plugins: {
          tooltip: {
            rtl: true
          },
          legend: {
            rtl: true,
            display: true,
            labels: {
              color: colors.bodyColor,
              font: {
                size: '13px',
                family: fontFamily
              }
            }
          },
        },
        scales: {
          x: {
            display: true,
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          },
          y: {
            grid: {
              display: true,
              color: colors.gridBorder,
              borderColor: colors.gridBorder,
            },
            ticks: {
              color: colors.secondary,
              font: {
                size: 12
              }
            }
          }
        }
      }
    });
  }

})();