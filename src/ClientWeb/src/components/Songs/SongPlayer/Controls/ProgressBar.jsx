import React from 'react';

function ProgressBar() {
  return (
    <div className='w-full h-5 flex justify-around items-center gap-3'>
      <span className='text-sm cursor-default text-white'>00.00</span>
      <input
        id='progress'
        className='w-full h-1 bg-white rounded-sm cursor-pointer dark:bg-gray-700 overflow-hidden hover:h-2 hover:rounded-lg hover:overflow-visible'
        // value='0'
        type='range'
        step='1'
        min='0'
        max='100'
      />
      <span className='text-sm cursor-default text-white'>03.22</span>
    </div>
  );
}

export default ProgressBar;
