﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canon_EOS_Remote
{
    class ErrorCodes
    {
        private static List<EdsError> _errorCodes;

        #region static constructors
        static ErrorCodes()
        {
            init();        
        }
        #endregion

        private static void init()
        {
            #region add ErrorCodes to List
            _errorCodes.Add(new EdsError(0x80000000, "EDS_ISSPECIFIC_MASK", ""));
            _errorCodes.Add(new EdsError(0x7F000000, "EDS_COMPONENTID_MASK", ""));
            _errorCodes.Add(new EdsError(0x00FF0000, "EDS_RESERVED_MASK", ""));
            _errorCodes.Add(new EdsError(0x0000FFFF, "EDS_ERRORID_MASK", ""));

            /*-----------------------------------------------------------------------
               ED-SDK Base Component IDs
            ------------------------------------------------------------------------*/
            _errorCodes.Add(new EdsError(0x01000000, "EDS_CMP_ID_CLIENT_COMPONENTID", ""));
            _errorCodes.Add(new EdsError(0x02000000, "EDS_CMP_ID_LLSDK_COMPONENTID", ""));
            _errorCodes.Add(new EdsError(0x03000000, "EDS_CMP_ID_HLSDK_COMPONENTID", ""));

            /*-----------------------------------------------------------------------
               ED-SDK Functin Success Code
            ------------------------------------------------------------------------*/
            _errorCodes.Add(new EdsError(0x00000000, "EDS_ERR_OK", ""));

            /*-----------------------------------------------------------------------
               ED-SDK Generic Error IDs
            ------------------------------------------------------------------------*/
            /* Miscellaneous errors */
            _errorCodes.Add(new EdsError(0x00000001, "EDS_ERR_UNIMPLEMENTED", ""));
            _errorCodes.Add(new EdsError(0x00000002, "EDS_ERR_INTERNAL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000003, "EDS_ERR_MEM_ALLOC_FAILED", ""));
            _errorCodes.Add(new EdsError(0x00000004, "EDS_ERR_MEM_FREE_FAILED", ""));
            _errorCodes.Add(new EdsError(0x00000005, "EDS_ERR_OPERATION_CANCELLED", ""));
            _errorCodes.Add(new EdsError(0x00000006, "EDS_ERR_INCOMPATIBLE_VERSION", ""));
            _errorCodes.Add(new EdsError(0x00000007, "EDS_ERR_NOT_SUPPORTED", ""));
            _errorCodes.Add(new EdsError(0x00000008, "EDS_ERR_UNEXPECTED_EXCEPTION", ""));
            _errorCodes.Add(new EdsError(0x00000009, "EDS_ERR_PROTECTION_VIOLATION", ""));
            _errorCodes.Add(new EdsError(0x0000000A, "EDS_ERR_MISSING_SUBCOMPONENT", ""));
            _errorCodes.Add(new EdsError(0x0000000B, "EDS_ERR_SELECTION_UNAVAILABLE", ""));

            /* File errors */
            _errorCodes.Add(new EdsError(0x00000020, "EDS_ERR_FILE_IO_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000021, "EDS_ERR_FILE_TOO_MANY_OPEN", ""));
            _errorCodes.Add(new EdsError(0x00000022, "EDS_ERR_FILE_NOT_FOUND", ""));
            _errorCodes.Add(new EdsError(0x00000023, "EDS_ERR_FILE_OPEN_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000024, "EDS_ERR_FILE_CLOSE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000025, "EDS_ERR_FILE_SEEK_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000026, "EDS_ERR_FILE_TELL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000027, "EDS_ERR_FILE_READ_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000028, "EDS_ERR_FILE_WRITE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000029, "EDS_ERR_FILE_PERMISSION_ERROR", ""));
            _errorCodes.Add(new EdsError(0x0000002A, "EDS_ERR_FILE_DISK_FULL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x0000002B, "EDS_ERR_FILE_ALREADY_EXISTS", ""));
            _errorCodes.Add(new EdsError(0x0000002C, "EDS_ERR_FILE_FORMAT_UNRECOGNIZED", ""));
            _errorCodes.Add(new EdsError(0x0000002D, "EDS_ERR_FILE_DATA_CORRUPT", ""));
            _errorCodes.Add(new EdsError(0x0000002E, "EDS_ERR_FILE_NAMING_NA", ""));

            /* Directory errors */
            _errorCodes.Add(new EdsError(0x00000040, "EDS_ERR_DIR_NOT_FOUND", ""));
            _errorCodes.Add(new EdsError(0x00000041, "EDS_ERR_DIR_IO_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000042, "EDS_ERR_DIR_ENTRY_NOT_FOUND", ""));
            _errorCodes.Add(new EdsError(0x00000043, "EDS_ERR_DIR_ENTRY_EXISTS", ""));
            _errorCodes.Add(new EdsError(0x00000044, "EDS_ERR_DIR_NOT_EMPTY", ""));

            /* Property errors */
            _errorCodes.Add(new EdsError(0x00000050, "EDS_ERR_PROPERTIES_UNAVAILABLE", ""));
            _errorCodes.Add(new EdsError(0x00000051, "EDS_ERR_PROPERTIES_MISMATCH", ""));
            _errorCodes.Add(new EdsError(0x00000053, "EDS_ERR_PROPERTIES_NOT_LOADED", ""));

            /* Function Parameter errors */
            _errorCodes.Add(new EdsError(0x00000060, "EDS_ERR_INVALID_PARAMETER", ""));
            _errorCodes.Add(new EdsError(0x00000061, "EDS_ERR_INVALID_HANDLE", ""));
            _errorCodes.Add(new EdsError(0x00000062, "EDS_ERR_INVALID_POINTER", ""));
            _errorCodes.Add(new EdsError(0x00000063, "EDS_ERR_INVALID_INDEX", ""));
            _errorCodes.Add(new EdsError(0x00000064, "EDS_ERR_INVALID_LENGTH", ""));
            _errorCodes.Add(new EdsError(0x00000065, "EDS_ERR_INVALID_FN_POINTER", ""));
            _errorCodes.Add(new EdsError(0x00000066, "EDS_ERR_INVALID_SORT_FN", ""));

            /* Device errors */
            _errorCodes.Add(new EdsError(0x00000080, "EDS_ERR_DEVICE_NOT_FOUND", ""));
            _errorCodes.Add(new EdsError(0x00000081, "EDS_ERR_DEVICE_BUSY", ""));
            _errorCodes.Add(new EdsError(0x00000082, "EDS_ERR_DEVICE_INVALID", ""));
            _errorCodes.Add(new EdsError(0x00000083, "EDS_ERR_DEVICE_EMERGENCY", ""));
            _errorCodes.Add(new EdsError(0x00000084, "EDS_ERR_DEVICE_MEMORY_FULL", ""));
            _errorCodes.Add(new EdsError(0x00000085, "EDS_ERR_DEVICE_INTERNAL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000086, "EDS_ERR_DEVICE_INVALID_PARAMETER", ""));
            _errorCodes.Add(new EdsError(0x00000087, "EDS_ERR_DEVICE_NO_DISK", ""));
            _errorCodes.Add(new EdsError(0x00000088, "EDS_ERR_DEVICE_DISK_ERROR", ""));
            _errorCodes.Add(new EdsError(0x00000089, "EDS_ERR_DEVICE_CF_GATE_CHANGED", ""));
            _errorCodes.Add(new EdsError(0x0000008A, "EDS_ERR_DEVICE_DIAL_CHANGED", ""));
            _errorCodes.Add(new EdsError(0x0000008B, "EDS_ERR_DEVICE_NOT_INSTALLED", ""));
            _errorCodes.Add(new EdsError(0x0000008C, "EDS_ERR_DEVICE_STAY_AWAKE", ""));
            _errorCodes.Add(new EdsError(0x0000008D, "EDS_ERR_DEVICE_NOT_RELEASED", ""));

            /* Stream errors */
            _errorCodes.Add(new EdsError(0x000000A0, "EDS_ERR_STREAM_IO_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A1, "EDS_ERR_STREAM_NOT_OPEN", ""));
            _errorCodes.Add(new EdsError(0x000000A2, "EDS_ERR_STREAM_ALREADY_OPEN", ""));
            _errorCodes.Add(new EdsError(0x000000A3, "EDS_ERR_STREAM_OPEN_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A4, "EDS_ERR_STREAM_CLOSE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A5, "EDS_ERR_STREAM_SEEK_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A6, "EDS_ERR_STREAM_TELL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A7, "EDS_ERR_STREAM_READ_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A8, "EDS_ERR_STREAM_WRITE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000A9, "EDS_ERR_STREAM_PERMISSION_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000AA, "EDS_ERR_STREAM_COULDNT_BEGIN_THREAD", ""));
            _errorCodes.Add(new EdsError(0x000000AB, "EDS_ERR_STREAM_BAD_OPTIONS", ""));
            _errorCodes.Add(new EdsError(0x000000AC, "EDS_ERR_STREAM_END_OF_STREAM", ""));

            /* Communications errors */
            _errorCodes.Add(new EdsError(0x000000C0, "EDS_ERR_COMM_PORT_IS_IN_USE", ""));
            _errorCodes.Add(new EdsError(0x000000C1, "EDS_ERR_COMM_DISCONNECTED", ""));
            _errorCodes.Add(new EdsError(0x000000C2, "EDS_ERR_COMM_DEVICE_INCOMPATIBLE", ""));
            _errorCodes.Add(new EdsError(0x000000C3, "EDS_ERR_COMM_BUFFER_FULL", ""));
            _errorCodes.Add(new EdsError(0x000000C4, "EDS_ERR_COMM_USB_BUS_ERR", ""));

            /* Lock/Unlock */
            _errorCodes.Add(new EdsError(0x000000D0, "EDS_ERR_USB_DEVICE_LOCK_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000D1, "EDS_ERR_USB_DEVICE_UNLOCK_ERROR", ""));

            /* STI/WIA */
            _errorCodes.Add(new EdsError(0x000000E0, "EDS_ERR_STI_UNKNOWN_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000E1, "EDS_ERR_STI_INTERNAL_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000E2, "EDS_ERR_STI_DEVICE_CREATE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000E3, "EDS_ERR_STI_DEVICE_RELEASE_ERROR", ""));
            _errorCodes.Add(new EdsError(0x000000E4, "EDS_ERR_DEVICE_NOT_LAUNCHED", ""));

            _errorCodes.Add(new EdsError(0x000000F0, "EDS_ERR_ENUM_NA", ""));
            _errorCodes.Add(new EdsError(0x000000F1, "EDS_ERR_INVALID_FN_CALL", ""));
            _errorCodes.Add(new EdsError(0x000000F2, "EDS_ERR_HANDLE_NOT_FOUND", ""));
            _errorCodes.Add(new EdsError(0x000000F3, "EDS_ERR_INVALID_ID", ""));
            _errorCodes.Add(new EdsError(0x000000F4, "EDS_ERR_WAIT_TIMEOUT_ERROR", ""));

            /* PTP */
            _errorCodes.Add(new EdsError(0x00002003, "EDS_ERR_SESSION_NOT_OPEN", ""));
            _errorCodes.Add(new EdsError(0x00002004, "EDS_ERR_INVALID_TRANSACTIONID", ""));
            _errorCodes.Add(new EdsError(0x00002007, "EDS_ERR_INCOMPLETE_TRANSFER", ""));
            _errorCodes.Add(new EdsError(0x00002008, "EDS_ERR_INVALID_STRAGEID", ""));
            _errorCodes.Add(new EdsError(0x0000200A, "EDS_ERR_DEVICEPROP_NOT_SUPPORTED", ""));
            _errorCodes.Add(new EdsError(0x0000200B, "EDS_ERR_INVALID_OBJECTFORMATCODE", ""));
            _errorCodes.Add(new EdsError(0x00002011, "EDS_ERR_SELF_TEST_FAILED", ""));
            _errorCodes.Add(new EdsError(0x00002012, "EDS_ERR_PARTIAL_DELETION", ""));
            _errorCodes.Add(new EdsError(0x00002014, "EDS_ERR_SPECIFICATION_BY_FORMAT_UNSUPPORTED", ""));
            _errorCodes.Add(new EdsError(0x00002015, "EDS_ERR_NO_VALID_OBJECTINFO", ""));
            _errorCodes.Add(new EdsError(0x00002016, "EDS_ERR_INVALID_CODE_FORMAT", ""));
            _errorCodes.Add(new EdsError(0x00002017, "EDS_ERR_UNKNOWN_VENDER_CODE", ""));
            _errorCodes.Add(new EdsError(0x00002018, "EDS_ERR_CAPTURE_ALREADY_TERMINATED", ""));
            _errorCodes.Add(new EdsError(0x0000201A, "EDS_ERR_INVALID_PARENTOBJECT", ""));
            _errorCodes.Add(new EdsError(0x0000201B, "EDS_ERR_INVALID_DEVICEPROP_FORMAT", ""));
            _errorCodes.Add(new EdsError(0x0000201C, "EDS_ERR_INVALID_DEVICEPROP_VALUE", ""));
            _errorCodes.Add(new EdsError(0x0000201E, "EDS_ERR_SESSION_ALREADY_OPEN", ""));
            _errorCodes.Add(new EdsError(0x0000201F, "EDS_ERR_TRANSACTION_CANCELLED", ""));
            _errorCodes.Add(new EdsError(0x00002020, "EDS_ERR_SPECIFICATION_OF_DESTINATION_UNSUPPORTED", ""));
            _errorCodes.Add(new EdsError(0x0000A001, "EDS_ERR_UNKNOWN_COMMAND", ""));
            _errorCodes.Add(new EdsError(0x0000A005, "EDS_ERR_OPERATION_REFUSED", ""));
            _errorCodes.Add(new EdsError(0x0000A006, "EDS_ERR_LENS_COVER_CLOSE", ""));
            _errorCodes.Add(new EdsError(0x0000A101, "EDS_ERR_LOW_BATTERY", ""));
            _errorCodes.Add(new EdsError(0x0000A102, "EDS_ERR_OBJECT_NOTREADY", ""));


            /* Capture Error */
            _errorCodes.Add(new EdsError(0x00008D01, "EDS_ERR_TAKE_PICTURE_AF_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D02, "EDS_ERR_TAKE_PICTURE_RESERVED", ""));
            _errorCodes.Add(new EdsError(0x00008D03, "EDS_ERR_TAKE_PICTURE_MIRROR_UP_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D04, "EDS_ERR_TAKE_PICTURE_SENSOR_CLEANING_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D05, "EDS_ERR_TAKE_PICTURE_SILENCE_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D06, "EDS_ERR_TAKE_PICTURE_NO_CARD_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D07, "EDS_ERR_TAKE_PICTURE_CARD_NG", ""));
            _errorCodes.Add(new EdsError(0x00008D08, "EDS_ERR_TAKE_PICTURE_CARD_PROTECT_NG", ""));


            _errorCodes.Add(new EdsError(0x000000F5, "EDS_ERR_LAST_GENERIC_ERROR_PLUS_ONE", ""));

            #endregion
        }

        #region Methods

        /* Added on 09-05-2011 12:21
         * This method is for getting the error code string and description.
         * Param : errorCodeNumber to search in the errorCode Lists.
         * return the EdsError with complete informations.
         */
        public static EdsError getErrorDataWithCodeNumber(uint errorCodeNumber){
            EdsError tmpError = new EdsError() ;
            tmpError.ErrorCodeNumber = errorCodeNumber;
            for (int i = 0; i <= _errorCodes.Count; i++)
            {
                if (_errorCodes.ElementAt(i).ErrorCodeNumber == tmpError.ErrorCodeNumber)
                {
                    tmpError.ErrorCodeString = _errorCodes.ElementAt(i).ErrorCodeString;
                    tmpError.ErrorDescription = _errorCodes.ElementAt(i).ErrorDescription;
                }
                else
                {
                    tmpError.ErrorCodeString = "ErrorCodeString not found";
                    tmpError.ErrorDescription = "ErrorDescription not found";
                }
            }
            return tmpError;
        }

        #endregion
    }
}
