/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect, useState } from 'react';
import SongItem from '../SongItem/SongItem';
import useFetch from '../../../hooks/useFetch';
import config from '../../../config';
import { PropagateLoader } from 'react-spinners';

import { FaPlay } from 'react-icons/fa';
import { MdKeyboardArrowRight } from 'react-icons/md';
import Loading from 'components/widgets/Loading';
import PlayerControl from '../SongPlayer/Controls';

function Songs() {
  const [pageNumber, setPageNumber] = useState(1);
  const { response, loading, error, axiosFetchAsync } = useFetch();

  useEffect(() => {
    const query = new URLSearchParams({
      PageNumber: pageNumber || 1,
      PageSize: 10,
    });
    axiosFetchAsync({
      method: 'get',
      url: config.endpoints.songs,
      params: query,
    });
  }, [pageNumber]);

  return (
    <div className='p-4'>
      {loading ? (
        <Loading />
      ) : (
        <div>
          {error ?? (
            <div>
              <p>{error.message}</p>
            </div>
          )}
          <>
            <div className='flex justify-between my-2'>
              <li className='list-none flex items-center text-3xl text-primary'>
                Bài Hát
                <MdKeyboardArrowRight className='container_profile--layout__sum--head_left__icon' />
              </li>
              <li className='list-none flex items-center rounded-3xl text-white px-4 py-3 gap-2 bg-primary cursor-pointer  hover:opacity-80 active:opacity-90'>
                <FaPlay />
                <span className=''>Phát tất cả</span>
              </li>
            </div>
            {response.items.map((song, index) => (
              <SongItem
                key={song.id}
                song={song}
                currentIndex={index}
              />
            ))}
          </>
        </div>
      )}
    </div>
  );
}

export default Songs;
