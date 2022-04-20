import * as React from "react";
import Chart from 'react-apexcharts';
import "./donut.css";

interface IProps {
  series: number[] | null,
  labels: string[] | null
}

class Donut extends React.Component<IProps, any> {

  constructor(props: IProps) {
    super(props);

    this.state = {

      series: this.props.series,
      options: {
        chart: {
          type: 'donut',
        },
        labels: this.props.labels,
        legend: {
          fontSize: "15px"
        },
        responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'left'
            }
          }
        }]
      }
    };
  }

  render() {

    return (
      <div className="donut">
        <Chart options={this.state.options} series={this.props.series} type="donut" width="380" />
      </div>
    );
  }
}

export default Donut;
