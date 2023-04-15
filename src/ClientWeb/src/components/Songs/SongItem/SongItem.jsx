import React from 'react';
import { FaHeart, FaPlay } from 'react-icons/fa';
import { images } from '../../../assets';
import { Link } from 'react-router-dom';
import { formatDuration } from '../../../utils/Utils';
import { MdMoreHoriz } from 'react-icons/md';
import { useDispatch } from 'react-redux';
import {
  changeIconPlay,
  setAutoPlay,
  setCurrnetIndexPlaylist,
  setSongId,
} from 'store/features/audioSlice';

function SongItem(props) {
  const { song, currentIndex } = props;
  const imageUrl = song.imageUrl == null ? images.song_default : song.imageUrl;

  const dispatch = useDispatch();

  const handlePlay = (id, currentIndex) => {
    dispatch(setSongId(id));
    dispatch(setCurrnetIndexPlaylist(currentIndex));
    dispatch(changeIconPlay(true));
    dispatch(setAutoPlay(true));
  };

  return (
    <div
      className='flex items-center justify-between gap-5 w-full p-2 rounded cursor-pointer group hover:bg-accent hover:text-white'
      onClick={() => {
        handlePlay(song.id, currentIndex);
      }}
    >
      <div
        className='w-16 h-16 object-cover flex rounded-md bg-cover items-center justify-center'
        style={{ backgroundImage: `url(${imageUrl})` }}
      >
        <FaPlay
          className='group-hover:block hidden'
          color='white'
          size={30}
        />
      </div>

      <div className='flex flex-col w-[calc(100%-20%-40%)]'>
        <h5 className='inline-block'>{song.name}</h5>
        <span className='flex justify-start'>
          {song.artists.map((artist) => {
            console.log(artist);
            return (
              <Link
                className='cursor-pointer no-underline text-text hover:underline group-hover:text-hoverText'
                key={artist.id}
                to={''}
              >
                {artist.fullName}
              </Link>
            );
          })}
        </span>
      </div>
      <div className='w-[calc(20%-50px))]'>{formatDuration(song.duration)}</div>
      <div className='w-2/5 flex justify-end gap-5 p-4'>
        {/* <FaMicrophone /> */}
        <FaHeart className='w-6 h-6 rounded-full p-1 cursor-pointer' />
        <MdMoreHoriz className='w-6 h-6 rounded-full p-1 cursor-pointer' />
      </div>
    </div>
  );
}

export default SongItem;
