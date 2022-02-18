import { compose, Dispatch } from 'redux';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import InvitePageView from './invite-page-view';
import { inviteUserOpearation } from '../../../store/user/user-operations';

const mapDispatchToProps = (disputch: Dispatch) => {
  return {
    inviteUser: async (userName: string, roomId: string) => {
      return disputch(await inviteUserOpearation(userName, roomId));
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(InvitePageView);
