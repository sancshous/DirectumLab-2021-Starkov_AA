import {Api} from "./api";
import authService from "../service/auth-service";
import {IRoom, IUser} from "../store/types";

const baseUrl = 'http://localhost:5000/api';

const api = new Api(baseUrl);

export interface IUserRequest {
  user: IUser,
  roomId: string,
}

const getHeaders = () => {
  return {
    'X-User-Id': authService.get()
  };
}

export const createRoomRequest = async (userName: string, roomName: string): Promise<IUserRequest> => {
  const response = await api.post<{roomId: string, user: IUser}>(
    'Room/Create',
    {
      userName: userName,
      roomName: roomName
    },
    getHeaders()
  );
  authService.set(response.user.id);
  return response;
}

export const loadRoomRequest = async (id: string): Promise<IRoom | null> => {
  return await api.get<IRoom>(`room?id=${id}`, getHeaders());
}


