import { margin } from '@mui/system';
import ReactModal from 'react-modal';

export default function DialogCreateResumeTag({ children, ...props }) {
    return <ReactModal
        {...props}
        style={{
            overlay: {
                zIndex: 9999,
                position: 'fixed',
                top: 0,
                left: 0,
                right: 0,
                bottom: 0,
                backgroundColor: 'rgba(0, 0, 0, 0.45)'
            },
            content: {
                position: 'absolute',
                width: 'fit-content',
                height: 'min-content',
                margin: 'auto',
                textWrap: 'nowrap',
                border: '1px solid #ccc',
                background: '#fff',
                overflow: 'auto',
                WebkitOverflowScrolling: 'touch',
                borderRadius: '0.5rem',
                outline: 'none',
                padding: '20px',
                overflow: 'visible'
            }
        }}>
        {children}
    </ReactModal>;
};