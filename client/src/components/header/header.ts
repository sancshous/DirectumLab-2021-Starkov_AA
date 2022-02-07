import {IRootState} from "../../store/types";
import {connect} from "react-redux";
import HeaderView from "./header-view";

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user
  }
}

export default connect(mapStateToProps)(HeaderView);
