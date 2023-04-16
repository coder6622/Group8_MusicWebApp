import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { audioSliceReducer } from './features/audioSlice';

const reducer = combineReducers({
  audioPlayer: audioSliceReducer,
});

export const store = configureStore({
  reducer: reducer,
  devTools: true,
});
