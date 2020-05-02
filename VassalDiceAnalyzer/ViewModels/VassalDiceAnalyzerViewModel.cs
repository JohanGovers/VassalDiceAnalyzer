using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.BarChart.Axes;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Axes;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.Common.Wrappers;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components.Web;
using VassalDiceAnalyzer.Data;
using VassalDiceAnalyzer.Data.Samples;
using VassalDiceAnalyzer.Domain;

namespace VassalDiceAnalyzer.ViewModels
{
    public interface IVassalDiceAnalyzerViewModel
    {
        public string LogText { get; set; }
        public List<PlayerDiceRolls> PlayerDiceRolls { get; }
        public BarConfig DiceResultsBarChartConfig { get; }
        public BarConfig[] DiceHotnessChartConfigs { get; }

        string ShowPercentageFor(int x, int y);
        Task UseExampleFile1Async();
    }

    public class VassalDiceAnalyzerViewModel : IVassalDiceAnalyzerViewModel
    {
        // TODO: Nicer highlight colors.
        private string[] _barColors = { "#1d36b5", "#ad1515", "#1a8234", "#b01c97" };

        private readonly IVassalLogParser _logParser;
        private readonly ISampleDataLoader _sampleDataLoader;
        private string _logText;

        public string LogText
        {
            get => _logText;
            set
            {
                _logText = value;
                ParseLogText();
            }
        }

        public List<PlayerDiceRolls> PlayerDiceRolls { get; set; }

        public BarConfig DiceResultsBarChartConfig { get; private set; }
        public BarConfig[] DiceHotnessChartConfigs { get; private set; }
        
        public VassalDiceAnalyzerViewModel(IVassalLogParser logParser, ISampleDataLoader sampleDataLoader)
        {
            _logParser = logParser;
            _sampleDataLoader = sampleDataLoader;
            PlayerDiceRolls = new List<PlayerDiceRolls>();
        }
        
        public void ParseLogText()
        {
            PlayerDiceRolls.Clear();

            PlayerDiceRolls =_logParser.ParseLog(LogText);

            UpdateDiceResultsChart();
            UpdateDiceHotnessCharts();
        }

        private void UpdateDiceResultsChart()
        {
            DiceResultsBarChartConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Dice Results %"
                    },
                    Scales = new BarScales
                    {
                        XAxes = new List<CartesianAxis>
                        {
                            new BarCategoryAxis
                            {
                                BarPercentage = 0.5,
                                BarThickness = BarThickness.Flex
                            }
                        },
                        YAxes = new List<CartesianAxis>
                        {
                            new BarLinearCartesianAxis
                            {
                                Ticks = new LinearCartesianTicks
                                {
                                    BeginAtZero = true
                                }
                            }
                        }
                    }
                }
            };

            DiceResultsBarChartConfig.Data.Labels.AddRange(new[] { "Ones %", "Twos %", "Threes %", "Fours %", "Fives %", "Sixes %" });

            for (var index = 0; index < PlayerDiceRolls.Count; index++)
            {
                var player = PlayerDiceRolls[index];
                var barDataSet = new BarDataset<DoubleWrapper>
                {
                    Label = player.PlayerName,
                    BackgroundColor = _barColors[index%4],
                    BorderWidth = 0,
                    HoverBackgroundColor = _barColors[index % 4],
                    HoverBorderColor = ColorUtil.RandomColorString(),
                    HoverBorderWidth = 1,
                    BorderColor = "#ffffff"
                };

                barDataSet.AddRange(new double[]
                {
                    PercentageWithTwoDecimals(player.TotalOnesRolled, player.TotalDicesRolled), 
                    PercentageWithTwoDecimals(player.TotalTwosRolled, player.TotalDicesRolled), 
                    PercentageWithTwoDecimals(player.TotalThreesRolled, player.TotalDicesRolled), 
                    PercentageWithTwoDecimals(player.TotalFoursRolled, player.TotalDicesRolled),
                    PercentageWithTwoDecimals(player.TotalFivesRolled, player.TotalDicesRolled), 
                    PercentageWithTwoDecimals(player.TotalSixesRolled, player.TotalDicesRolled)
                }.Wrap());
                DiceResultsBarChartConfig.Data.Datasets.Add(barDataSet);
            }
        }

        private void UpdateDiceHotnessCharts()
        {
            var diceHotnessChartConfigs = new List<BarConfig>();
            for (var index = 0; index < PlayerDiceRolls.Count; index++)
            {
                var player = PlayerDiceRolls[index];
                var diceHotnessConfig = new BarConfig
                {
                    Options = new BarOptions
                    {
                        Title = new OptionsTitle
                        {
                            Display = true,
                            Text = $"Dice hotness {player.PlayerName}"
                        },
                        Scales = new BarScales
                        {
                            XAxes = new List<CartesianAxis>
                            {
                                new BarCategoryAxis
                                {
                                    BarPercentage = 0.5,
                                    BarThickness = BarThickness.Flex
                                }
                            },
                            YAxes = new List<CartesianAxis>
                            {
                                new BarLinearCartesianAxis
                                {
                                    Ticks = new LinearCartesianTicks
                                    {
                                        BeginAtZero = true
                                    }
                                }
                            }
                        }
                    }
                };

                diceHotnessConfig.Data.Labels.AddRange(player.RollAverages.Select(a => a.RangeMax.ToString()));

                var barDataSet = new BarDataset<DoubleWrapper>
                {
                    Label = player.PlayerName,
                    BackgroundColor = _barColors[index % 4],
                    BorderWidth = 0,
                    HoverBackgroundColor = _barColors[index % 4],
                    HoverBorderColor = ColorUtil.RandomColorString(),
                    HoverBorderWidth = 1,
                    BorderColor = "#ffffff"
                };

                barDataSet.AddRange(player.RollAverages.Select(a => (double)a.Count).ToArray().Wrap());

                diceHotnessConfig.Data.Datasets.Add(barDataSet);
                diceHotnessChartConfigs.Add(diceHotnessConfig);
            }

            DiceHotnessChartConfigs = diceHotnessChartConfigs.ToArray();
        }

        public string ShowPercentageFor(int x, int y)
        {
            return PercentageWithTwoDecimals(x,y).ToString("0.##") + " %";
        }

        public double PercentageWithTwoDecimals(int x, int y)
        {
            var percentageTimes100 = 100 * (100f * x / y);
            return Math.Round(percentageTimes100) / 100f;
        }

        public async Task UseExampleFile1Async()
        {
            LogText = await _sampleDataLoader.GetSample1Async();
        }
    }
}
