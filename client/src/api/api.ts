import {IRoom, IUser} from "../store/types";
import {room, store, story, user} from "../store/mockStore";


const random = (): string => {
  return Math.round(Math.random() * (100 - 1) + 1).toString(10);
};

export const createRoom = (userName: string, roomName: string): {roomId: string; user: IUser} => {
  user.id = random();
  user.name = userName;

  room.id = random();
  room.name = roomName;
  room.ownerId = user.id;
  room.users.push(user);

  store.user = user;
  store.room = room;

  return {
    roomId: room.id,
    user
  };
};

export const loadRoom = (id: string): IRoom | null => {
  if(store.room != null && store.room.id === id)
    return store.room;
  return null;
}

export const createStory = (roomId: string, storyName: string): IRoom | null => {
  story.id = random();
  story.name = storyName;

  const { room } = store;
  if(room?.id === roomId)
    room?.stories.push(story);

  return room;
}

export const vote = (roomId: string, storyId: string, value: string): IRoom | null => {
  if(store.room?.id === roomId) {
    const currentStory = store.room.stories.find((s) => s.id === storyId);
    if (currentStory) {
      currentStory.votes[user.id] = value;
    }
  }
  return room;
}

export const calcAverage = (roomId: string, storyId: string): IRoom | null => {
  if(store.room?.id === roomId) {
    const currentStory = store.room.stories.find((s) => s.id === storyId);
    if (currentStory) {
      currentStory.average = store.room.users.map((user) => (
        +(currentStory.votes[user.id]))).reduce((a, b) => (a + b))
    }
  }
  return room;
}

export const join = (roomId: string, userName: string): IUser => {
  const newUser: IUser = {
    id: random(),
    name: userName
  };
  if(store.room?.id === roomId)
    room.users.push(newUser);

  return newUser;
}
