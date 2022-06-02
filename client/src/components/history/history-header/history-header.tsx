import * as React from "react";
import download from "../../../images/download.svg";
import Button from "../../button/button";
import * as XLSX from "xlsx";
import { saveAs } from 'file-saver';
import "./history-header.css";

interface IProps {
  mark: number | undefined
}

class HistoryHeader extends React.Component<IProps, any> {
  constructor(props: IProps) {
    super(props);
    this.handleDownloadHistory = this.handleDownloadHistory.bind(this);
  }

  handleDownloadHistory = () => {
    const wb = XLSX.utils.table_to_book(document.getElementById('tableH'), {sheet:"Sheet JS"});
    const wbout = XLSX.write(wb, {bookType:'xlsx', bookSST:true, type: 'binary'});

    function s2ab(s: string) {

      const buf = new ArrayBuffer(s.length);
      const view = new Uint8Array(buf);
      for (let i=0; i<s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
      return buf;
    }
    saveAs(new Blob([s2ab(wbout)],{type:"application/octet-stream"}), 'test.xlsx');
  }

  render() {
    return <header className="history__header">
      <div className="history__header-container">Completed Stories
        <div className="history__mark">{this.props.mark}</div>
      </div>
      <Button onClick={this.handleDownloadHistory} className={'history__btn-download'} title={<img src={download} />} />
    </header>
      ;
  }
}

export default HistoryHeader;
