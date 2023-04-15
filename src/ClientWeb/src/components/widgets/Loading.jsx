import React from 'react';
import { PropagateLoader } from 'react-spinners';
import variable from 'components/GlobalStyles/GlobalStyles.scss';

const color = { primaryColor: variable.primaryColor };

function Loading() {
  return (
    <PropagateLoader
      className='text-accent absolute left-2/4 top-8'
      color={color.primaryColor}
    />
  );
}

export default Loading;
