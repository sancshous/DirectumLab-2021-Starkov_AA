import {Api} from "./api";
import {ICard, IDiscussion, IRoom, IUser, IVote} from "../store/types";

const baseUrl = 'http://localhost:5000/api';

export const api = new Api(baseUrl);

export const createUserRequest = async (userName: string): Promise<IUser | null> => {
  const response = await api.get<IUser>(`User/Create?name=${userName}`);
  if (response != null) {
    localStorage.setItem('userId', response.id);
  }
  return response;
}

export const createRoomRequest = async (userName: string, roomName: string): Promise<IRoom | null> => {
  const userInfo = await createUserRequest(userName);
  const response = await api.get<IRoom>(`Room/Create?name=${roomName}&ownerId=${userInfo?.id}`);
  return response;
}

export const getRoomInfoRequest = async (roomId: string): Promise<IRoom | null> => {
  const response = await api.get<IRoom>(`Room/GetRoomInfo?roomId=${roomId}`);
  return response;
}

export const searchRoom = async (roomId: string): Promise<boolean | null> => {
  return await api.post<boolean>(`api/Room/SearchRoom?roomId=${roomId}`);
};

export const searchUserRequest = async (userId: string, roomId: string): Promise<IUser | null> => {
  let user = null;
  try {
    user = await api.post<IUser | null>(`api/Room/SearchUser?userId=${userId}&roomId=${roomId}`);
    return user;
  } catch (e) {
    return null;
  }
};

export const createDiscussionRequest = async (roomId: string, title: string): Promise<IDiscussion | null> => {
  const response = await api.get<IDiscussion>(`Discussion/Create?roomId=${roomId}&title=${title}`);
  return response;
}

export const getDiscussionListRequest = async (roomId: string): Promise<IDiscussion[] | null> => {
  const response = await api.get<IDiscussion[]>(`Discussion/GetDiscussionList?roomId=${roomId}`);
  return response;
}

export const getCardsRequest = async (): Promise<ICard[] | null> => {
  const response = await api.get<ICard[]>(`Card/GetCards`);
  return response;
}

export const addVoteRequest = async (cardId: string, userId: string, discussionId: string): Promise<IVote | null> => {
  const response = await api.post<IVote>(`Discussion/AddVote?cardId=${cardId}&userId=${userId}&discussionId=${discussionId}`);
  return response;
}

export const addUserRequest = async (roomId: string, userId: string): Promise<IRoom | null> => {
  const response = api.post<IRoom>(`Room/AddUser?roomId=${roomId}&userId=${userId}`);
  return response;
}

export const closeDiscussionRequest = async (discussionId: string): Promise<IDiscussion | null> => {
  const response = await api.post<IDiscussion>(`Discussion/Close?discussionId=${discussionId}`);
  return response;
}


