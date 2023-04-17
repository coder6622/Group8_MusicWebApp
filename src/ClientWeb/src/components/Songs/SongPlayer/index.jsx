/* eslint-disable react-hooks/exhaustive-deps */
import React, { useRef } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import PlayerControl from './Controls';
import {
  changeIconPlay,
  setCurrentTime,
  setCurrnetIndexPlaylist,
  setDuration,
  setLyric,
  setSrcAudio,
} from 'store/features/audioSlice';
import { useEffect } from 'react';
import useFetch from 'hooks/useFetch';
import { getSongPlayer } from 'services/SongRepository';
import { setInfoSongPlayer } from 'store/features/audioSlice';
import { isEmptyOrSpaces } from 'utils/Utils';
import Lyric from './Lyric';

export default function SongPlayer() {
  const dispatch = useDispatch();
  const audioDispatch = useDispatch();

  const { songId, isLoop, songUrl, currentIndexPlaylist, playlistSong } =
    useSelector((state) => state.audioPlayer);

  const { response, axiosFetchAsync } = useFetch();

  const audioRef = useRef(null);

  useEffect(() => {
    console.log(songId);
    if (isEmptyOrSpaces(songId)) {
      console.log('Song id not found');
    } else {
      axiosFetchAsync(getSongPlayer(songId));
    }
  }, [songId, dispatch]);

  useEffect(() => {
    console.log(process.env.REACT_APP_PUBLIC_URL + response.lrcUrl + '.lrc');
    response.songUrl
      ? dispatch(
          setSrcAudio(
            process.env.REACT_APP_PUBLIC_URL + response.songUrl + '.mp3',
          ),
        )
      : dispatch(setSrcAudio(''));

    dispatch(
      setInfoSongPlayer({
        name: response.name,
        imageUrl: response.imageUrl,
        artistsName: response.artistNames,
        artists: response.artists,
      }),
    );
    console.log(response.lyrics);
    dispatch(setLyric(response.lyrics));
  }, [response]);

  return (
    <>
      {songId ? <PlayerControl songRef={audioRef.current} /> : ''}

      <audio
        ref={audioRef}
        src={songUrl}
        className='hidden'
        loop={isLoop}
        autoPlay={true}
        hidden
        onTimeUpdate={() => {
          if (audioRef.current) {
            audioDispatch(setCurrentTime(audioRef.current.currentTime));
          }
        }}
        onLoadedData={() => {
          if (audioRef.current) {
            audioDispatch(setDuration(audioRef.current.duration));
          }
        }}
        onEnded={() => {
          if (!isLoop) {
            audioDispatch(setCurrentTime(0));
            audioDispatch(changeIconPlay(false));

            if (playlistSong !== undefined && playlistSong.length > 0) {
              let currentIndex;

              if (currentIndexPlaylist === playlistSong.length - 1) {
                currentIndex = 0;
              } else {
                currentIndex = currentIndexPlaylist + 1;
              }
              audioDispatch(setCurrnetIndexPlaylist(currentIndex));
              audioDispatch(changeIconPlay(true));
            }
          }
        }}
      />

      <Lyric />
    </>
  );
}
