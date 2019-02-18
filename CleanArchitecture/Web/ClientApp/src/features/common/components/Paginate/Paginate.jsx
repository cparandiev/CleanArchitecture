import React, { Component } from 'react';
import ReactPaginate from 'react-paginate';
import MaterialIcon from 'material-icons-react';
import PropTypes from 'prop-types';

class Paginate extends Component {
    render() {
        const { pageCount, onPageChange} = this.props;

        return (
            <nav>
                <ReactPaginate
                    pageClassName='page-item'
                    pageLinkClassName='page-link'
                    previousClassName='page-item'
                    previousLinkClassName='page-link'
                    nextClassName='page-item'
                    nextLinkClassName='page-link'
                    previousLabel={<MaterialIcon icon="arrow_back_ios" size="14" />}
                    nextLabel={<MaterialIcon icon="arrow_forward_ios" size="14" />}
                    breakLabel={<MaterialIcon icon="more_horiz" size="14" />}
                    breakClassName={'page-item'}
                    breakLinkClassName='page-link'
                    pageCount={pageCount}
                    marginPagesDisplayed={2}
                    pageRangeDisplayed={5}
                    onPageChange={onPageChange}
                    containerClassName={'pagination justify-content-center'}
                    subContainerClassName={'pages pagination'}
                    activeClassName={'active'}
                />
            </nav>
        );
    }
}

Paginate.propTypes = {
    pageCount: PropTypes.number,
    onPageChange: PropTypes.func,
}

export default Paginate;