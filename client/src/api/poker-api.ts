import {Api} from "./api";
import authService from "../service/auth-service";
import {ICard, IDiscussion, IRoom, IUser, IVote} from "../store/types";

const baseUrl = 'http://localhost:5000/api';

const api = new Api(baseUrl);

const getHeaders = () => {
  return {
    'X-User-Id': authService.get()
  };
}

export const createUserRequest = async (userName: string): Promise<IUser | null> => {
  const response = await api.get<IUser>(`User/Create?name=${userName}`, getHeaders());
  authService.set((await response).id);
  return response;
}

export const createRoomRequest = async (userName: string, roomName: string): Promise<IRoom> => {
  const userInfo = await createUserRequest(userName);
  const response = await api.get<IRoom>(`Room/Create?name=${roomName}&ownerId=${userInfo?.id}`, getHeaders());
  return response;
}

export const getRoomInfoRequest = async (roomId: string): Promise<IRoom | null> => {
  const response = await api.get<IRoom>(`Room/GetRoomInfo?roomId=${roomId}`, getHeaders());
  return response;
}

export const createDiscussionRequest = async (roomId: string): Promise<IDiscussion | null> => {
  const response = await api.get<IDiscussion>(`Discussion/Create?roomId=${roomId}&title=Bingo`, getHeaders());
  return response;
}

export const getDiscussionListRequest = async (roomId: string): Promise<IDiscussion[] | null> => {
  const response = await api.get<IDiscussion[]>(`Discussion/GetDiscussionList?roomId=${roomId}`, getHeaders());
  return response;
}

export const getCardsRequest = async (): Promise<ICard[] | null> => {
  const response = await api.get<ICard[]>(`Card/GetCards`, getHeaders());
  return response;
}

export const addVoteRequest = async (cardId: string, userId: string, discussionId: string): Promise<IVote> => {
  const response = await api.get<IVote>(`Discussion/AddVote?cardId=${cardId}&userId=${userId}&discussionId=${discussionId}`);
  return response;
}

export const addUserRequest = async (roomId: string, userId: string): Promise<IRoom | null> => {
  const response = await api.post<IRoom>(`Room/AddUser?roomId=${roomId}&userId=${userId}`, getHeaders());
  return response;
}


