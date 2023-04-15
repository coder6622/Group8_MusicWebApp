import { configureStore } from '@reduxjs/toolkit';
import { audioSliceReducer } from './features/audioSlice';

const reducer = {
  audioPlayer: audioSliceReducer,
};

export const store = configureStore({
  reducer: reducer,
  devTools: true,
});
